using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DeletedBlight.Items
{
    public class HornofPlenty : ModItem
    {
        public override void SetDefaults() 
		{
            // These variables are orange for an AMAZING reason!
            // No seriously why are they orange?
            Item.width = 17;
            Item.height = 17;
            Item.scale = 2f;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.rare = ModContent.RarityType<Rarities.BlightGreen>();
            Item.value = Item.buyPrice(gold: 25);
            Item.potion = true; // Counts as a potion for the potion sickness debuff. Why doesn't it work with Quick Heal tho???
			Item.expert = true; // Only available in Expert mode
		}

        public override void GetHealLife(Player player, bool quickHeal, ref int healValue)
        {
            healValue = 250; // Ensure it heals 250 life regardless of other factors
        }
		public override void ModifyPotionDelay(Player player, ref int baseDelay)
        {
            baseDelay = 4200; // Set the potion sickness delay to 70 seconds (4200 ticks)
        }
    }
}