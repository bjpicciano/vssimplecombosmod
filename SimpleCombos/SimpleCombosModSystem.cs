using Vintagestory.API.Common;

namespace SimpleCombos
{
    public record SimpleCombosProperty(string animation, float attackPowerMultiplier, float attackRangeMultiplier);

    public class SimpleCombosModSystem : ModSystem
    {
        public override void Start(ICoreAPI api)
        {
            base.Start(api);

            api.RegisterItemClass("ItemSimpleCombos", typeof(ItemSimpleCombos));
            api.RegisterItemClass("ItemSpearSimpleCombos", typeof(ItemSpearSimpleCombos));
            api.RegisterCollectibleBehaviorClass("AnimationSimpleCombos", typeof(CollectibleBehaviorAnimationSimpleCombos));
        }
    }
}
