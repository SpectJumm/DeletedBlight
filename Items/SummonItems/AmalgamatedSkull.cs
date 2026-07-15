using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ShadowlightMod.NPCs.Bosses.DeletedBlight;
using Terraria.Audio;
namespace ShadowlightMod.Items.SummonItems
{
    
	public class AmalgamatedSkull : ModItem
	{
        public static readonly SoundStyle UseSound = new SoundStyle("ShadowlightMod/Sounds/SummonItems/ShadowlightModSummon");

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 28;
			Item.maxStack = 20;
			Item.rare = ItemRarityID.Red;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = true;
		}

        public override bool CanUseItem(Player player)
        {
            return player.ZoneOverworldHeight;
        }

		public override bool? UseItem(Player player)
		{
			return true;
		}
	}
}
