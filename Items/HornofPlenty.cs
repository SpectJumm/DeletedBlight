using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace DeletedBlight.Items
{
    public class HornofPlenty : ModItem
	{
		public static readonly int PotionDelayDecrease = -10;

		public static LocalizedText? RestoreLifeText { get; private set; }

		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(PotionDelayDecrease);

		public override void SetStaticDefaults() {
			RestoreLifeText = this.GetLocalization(nameof(RestoreLifeText));

			Item.ResearchUnlockCount = 1;
		}
    		public override void SetDefaults() {
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
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.buyPrice(gold: 25);

			Item.healLife = 250; // While we change the actual healing value in GetHealLife, Item.healLife still needs to be higher than 0 for the item to be considered a healing item
			Item.potion = true; // Makes it so this item applies potion sickness on use and allows it to be used with quick heal
		}
        public override void ModifyTooltips(List<TooltipLine> tooltips) {
			// Find the tooltip line that corresponds to 'Heals ... life'
			// See https://tmodloader.github.io/tModLoader/html/class_terraria_1_1_mod_loader_1_1_tooltip_line.html for a list of vanilla tooltip line names
			TooltipLine line = tooltips.FirstOrDefault(static x => x.Mod == "Terraria" && x.Name == "HealLife");

			if (line != null) {
				// Change the text to 'Heals max/2 (max/4 when quick healing) life'
				line.Text = Language.GetTextValue("CommonItemTooltip.RestoresLife", RestoreLifeText.Format(Main.LocalPlayer.statLifeMax2 / 2, Main.LocalPlayer.statLifeMax2 / 4));
			}
        }
    }

}