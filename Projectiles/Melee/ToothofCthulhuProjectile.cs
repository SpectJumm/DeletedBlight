using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DeletedBlight.Projectiles.Melee
{
	public class ToothofCthulhuProjectile : ModProjectile
	{
		
		public override void SetDefaults()
		{
            Projectile.CloneDefaults(ProjectileID.WoodenBoomerang);
			Projectile.width = 35;
			Projectile.height = 35;
            Projectile.scale = 0.5f;
			Projectile.aiStyle = ProjAIStyleID.Boomerang;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
			AIType = ProjectileID.EnchantedBoomerang;
		}

		// Additional hooks/methods here.
	}
}