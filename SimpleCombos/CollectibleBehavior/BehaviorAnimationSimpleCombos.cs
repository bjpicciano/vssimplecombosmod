using System.Diagnostics;
using System.Numerics;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace SimpleCombos
{
    internal class CollectibleBehaviorAnimationSimpleCombos : CollectibleBehaviorAnimationAuthoritative
    {
        readonly int COMBO_RESET_MS = 400;

        public SimpleCombosProperty[] combos;

        private int _comboIndex = 0;
        public int ComboIndex {
            get { return _comboIndex; }

            set {
                _comboIndex = value;
                if (_comboIndex == combos.Length) _comboIndex = 0;
            }
        }

        public CollectibleBehaviorAnimationSimpleCombos(CollectibleObject collObj) : base(collObj)
        {
        }

        public override void Initialize(JsonObject properties)
        {
            base.Initialize(properties);
            
            strikeSound = AssetLocation.Create(properties["strikeSound"].AsString("sounds/player/strike")/*, collObj.Code.Domain*/);
            combos = properties["combos"].AsArray<SimpleCombosProperty>();
        }

        public override void hitEntity(EntityAgent byEntity)
        {
            EntitySelection entitySelection = (byEntity as EntityPlayer)?.EntitySelection;
            if (byEntity.World.Side == EnumAppSide.Client)
            {
                IClientWorldAccessor clientWorldAccessor = byEntity.World as IClientWorldAccessor;
                if (byEntity.Attributes.GetInt("didattack") == 0)
                {
                    if (entitySelection != null)
                    {
                        clientWorldAccessor.TryAttackEntity(entitySelection);
                    }
                    clientWorldAccessor.AddCameraShake(0.25f);
                }
            }
            if (byEntity.Attributes.GetInt("didattack") == 0)
            {
                ComboIndex++;
                byEntity.Attributes.SetInt("didattack", 1);

                if (ComboIndex > 0)
                {
                    byEntity.World.RegisterCallback((dt) =>
                    {
                        if (byEntity.Attributes.GetInt("didattack") == 1)
                        {
                            ComboIndex = 0;
                        }
                    }, COMBO_RESET_MS);
                }
            }
        }

        //public string GetFpEnding()
        //{
        //    ICoreClientAPI capi = api as ICoreClientAPI;
        //    return capi?.World.Player.CameraMode == EnumCameraMode.FirstPerson ? ((api as ICoreClientAPI)?.Settings.Bool["immersiveFpMode"] == true ? "-ifp" : "-fp") : "";
        //}
    }
}
