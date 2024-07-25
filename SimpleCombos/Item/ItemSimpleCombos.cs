using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.GameContent;

namespace SimpleCombos
{
    internal class ItemSimpleCombos : Item
    {
        CollectibleBehaviorAnimationSimpleCombos animationSimpleCombos;
        
        SimpleCombosProperty Combo {
            get {
                int comboIndex = animationSimpleCombos.ComboIndex;
                return animationSimpleCombos.combos[comboIndex];
            }
        }

        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);

            animationSimpleCombos = GetCollectibleBehavior<CollectibleBehaviorAnimationSimpleCombos>(true);
        }

        public override string GetHeldTpHitAnimation(ItemSlot activeHotbarSlot, Entity byEntity)
        {
            return Combo.animation;
        }

        public override float GetAttackRange(IItemStack withItemStack)
        {
            return AttackRange * Combo.attackRangeMultiplier;
        }

        public override float GetAttackPower(IItemStack withItemStack)
        {
            return AttackPower * Combo.attackPowerMultiplier;
        }
    }

    internal class ItemSpearSimpleCombos : ItemSpear
    {
        CollectibleBehaviorAnimationSimpleCombos animationSimpleCombos;
        
        SimpleCombosProperty Combo {
            get {
                int comboIndex = animationSimpleCombos.ComboIndex;
                return animationSimpleCombos.combos[comboIndex];
            }
        }

        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);

            animationSimpleCombos = GetCollectibleBehavior<CollectibleBehaviorAnimationSimpleCombos>(true);
        }

        public override string GetHeldTpHitAnimation(ItemSlot activeHotbarSlot, Entity byEntity)
        {
            return Combo.animation;
        }

        public override float GetAttackRange(IItemStack withItemStack)
        {
            return AttackRange * Combo.attackRangeMultiplier;
        }

        public override float GetAttackPower(IItemStack withItemStack)
        {
            return AttackPower * Combo.attackPowerMultiplier;
        }
    }
}
