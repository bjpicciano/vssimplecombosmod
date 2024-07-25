using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Config;
using Vintagestory.API.Server;
using Vintagestory.GameContent;

namespace SimpleCombos
{
    public record SimpleCombosProperty(string animation, float attackPowerMultiplier, float attackRangeMultiplier);

    public class SimpleCombosModSystem : ModSystem
    {
        // Called on server and client
        // Useful for registering block/entity classes on both sides
        public override void Start(ICoreAPI api)
        {
            base.Start(api);

            api.RegisterItemClass("ItemSimpleCombos", typeof(ItemSimpleCombos));
            api.RegisterCollectibleBehaviorClass("AnimationSimpleCombos", typeof(CollectibleBehaviorAnimationSimpleCombos));
        }

        public override void StartServerSide(ICoreServerAPI api)
        {
            //api.Logger.Notification("Hello from template mod server side: " + Lang.Get("simplecombos:hello"));
        }

        public override void StartClientSide(ICoreClientAPI api)
        {
            //api.Logger.Notification("Hello from template mod client side: " + Lang.Get("simplecombos:hello"));
        }
    }
}
