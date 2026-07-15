using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria.Audio;

namespace ShadowlightMod.Projectiles.Melee
{
    public class TrapperTapperFlail : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.SolarWhipSword);
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
            // Vanilla code for the Solar Eruption's projectile
            if (Main.netMode != 2 && Projectile.localAI[0] == 0f)
            {
                SoundEngine.PlaySound(in SoundID.Item116, Entity.Center);
            }
            if (Projectile.localAI[1] > 0f)
            {
                Projectile.localAI[1] -= 1f;
            }
            Projectile.alpha -= 42;
            if (Projectile.alpha < 0)
            {
                Projectile.alpha = 0;
            }
            if (Projectile.localAI[0] == 0f)
            {
                Projectile.localAI[0] = Entity.velocity.ToRotation();
            }
            float num52 = (Projectile.localAI[0].ToRotationVector2().X >= 0f) ? 1 : (-1);
            if (Projectile.ai[1] <= 0f)
            {
                num52 *= -1f;
            }
            Vector2 spinningpoint = (num52 * (Projectile.ai[0] / 30f * ((float)Math.PI * 2f) - (float)Math.PI / 2f)).ToRotationVector2();
            spinningpoint.Y *= (float)Math.Sin(Projectile.ai[1]);
            if (Projectile.ai[1] <= 0f)
            {
                spinningpoint.Y *= -1f;
            }
            spinningpoint = spinningpoint.RotatedBy(Projectile.localAI[0]);
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] < 30f)
            {
                Entity.velocity += 48f * spinningpoint;
            }
            else
            {
                Projectile.Kill();
            }
        }
    }
}