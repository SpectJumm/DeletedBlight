using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DeletedBlight.Items
{
    public class HornofPlenty : ModItem // Gold named the sprite "Horn of Nasty" lol, the name must not be lost to the sands of time.
    {
        public override void SetDefaults() 
		{
            // These variables are orange for an AMAZING reason!
            // No seriously why are they orange? I have no clue and I don't like it.
            Item.width = 34; // TODO: Change the size of the sprite to these dimensions.
            Item.height = 34;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.rare = ModContent.RarityType<Rarities.BlightGreen>();
            Item.value = Item.buyPrice(gold: 25);
            Item.potion = true; // Counts as a potion for the potion sickness debuff.
			Item.expert = true; // Only available in Expert mode
		}

        public override void GetHealLife(Player player, bool quickHeal, ref int healValue) // This SHOULD make it work with Quick Heal.
        {
            healValue = 250; // Ensure it heals 250 life regardless of other factors
        }
		public override void ModifyPotionDelay(Player player, ref int baseDelay)
        {
            baseDelay = 4200; // Set the potion sickness delay to 70 seconds (4200 ticks)
        }
    }
}