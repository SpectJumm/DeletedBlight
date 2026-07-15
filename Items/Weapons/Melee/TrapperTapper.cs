using ShadowlightMod.Projectiles.Melee;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShadowlightMod.Items.Weapons.Melee
{
    public class TrapperTapper : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SolarEruption);
            Item.shoot = ModContent.ProjectileType<TrapperTapperFlail>();
            Item.rare = ItemRarityID.Lime;
            Item.value = Item.sellPrice(0, 2);
            Item.damage = 105;
        }
    }
}