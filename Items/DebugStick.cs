using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Graphics.Effects;

namespace ShadowlightMod.Items
{
    public class DebugStick : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.WoodenSword;

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.WoodenSword);
            Item.useStyle = ItemUseStyleID.RaiseLamp;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.color = Color.Purple;
        }

        public override bool? UseItem(Player player)
        {
            if (!Main.dedServ)
            {
                // Activate the screen shader
                Filters.Scene.Activate("ScreenShatter").GetShader().UseOpacity(1.0f);
                return true;

            }
            return true;
        }
    }
}