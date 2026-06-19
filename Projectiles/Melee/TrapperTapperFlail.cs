using Terraria;
using Terraria.ModLoader;

namespace DeletedBlight.Projectiles.Melee
{
    public class TrapperTapperFlail : ModFlailProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 40;
            Projectile.height = 44;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
        }

        public override void AI()
        {

            // Optional: Add custom visual effects or sounds here
        }
    }
}
