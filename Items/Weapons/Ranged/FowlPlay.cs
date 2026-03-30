    using Terraria;
    using Terraria.ModLoader;
    using Microsoft.Xna.Framework;
    using Terraria.DataStructures;
    using Terraria.ID;
    using DeletedBlight.Projectiles.Ranged;
    using DeletedBlight.Rarities;

namespace DeletedBlight.Items.Weapons.Ranged
    {
        public class FowlPlay : ModItem
        {
            public override void SetDefaults()
            {
                Item.width = 72;
                Item.height = 36;
                Item.useTime = 45;
                Item.useAnimation = 45;
                Item.useStyle = ItemUseStyleID.Shoot;
                Item.autoReuse = true;
                Item.rare = ModContent.RarityType<BlightGreen>();

                Item.DamageType = DamageClass.Ranged;
                Item.noMelee = true;
                Item.damage = 362;
                Item.knockBack = 5f;

                Item.shoot = ModContent.ProjectileType<EggBombFriendly>();
                Item.shootSpeed = 10f;
            }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			float numberProjectiles = 4;
			float rotation = MathHelper.ToRadians(15);

			position += Vector2.Normalize(velocity) * 15f;

			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))); // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(source, position, perturbedSpeed, ModContent.ProjectileType<BlightedFeatherFriendly>(), 72, knockback, player.whoAmI);
			}

			return true; // return false to stop vanilla from calling Projectile.NewProjectile.
		}

        public override Vector2? HoldoutOffset() {
            return new Vector2(-8f, -2f);
        }
    }
}