using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DeletedBlight.Items
{
    public class HornofPlenty : ModItem
    {
        public override void SetDefaults()
		{
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
            Item.potionDelay = 4200; // 70 seconds of potion sickness
            Item.healLife = 250; // Heals 250 life on use
            Item.potion = true; // Counts as a potion for the potion sickness debuff. Why doesn't it work with Quick Heal tho???
			Item.expert = true; // Only available in Expert mode
		}
    }
}