using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DeletedBlight.Projectiles.Summons;

namespace DeletedBlight.Items.Weapons.DisposableSummoner
{

// Since this is the first of these "disposable summoner" items, I should explain what they are.
// Basically, the minions summoned with these will suicide-bomb the target or be used up in some way, requiring continuous reuse of the item.
// They'd do summon tag damage too, making them an alternative to whips.

    public class ShadowflameLantern : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 26;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.DamageType = DamageClass.Summon;
            Item.consumable = false;
            Item.noMelee = true;
        }
        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_ItemUse(Item), player.Center, Vector2.Zero, ModContent.ProjectileType<ShadowflameApparitionFriendly>(), 0, 0f, player.whoAmI);
				player.AddBuff(Item.buffType, 100);
            }
            return true;
        }    
    }
}