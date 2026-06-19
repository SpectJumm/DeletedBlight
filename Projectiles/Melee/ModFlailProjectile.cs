using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;


// VIBECODED SLOP
// MUST REPLACE IMMEDIATELY
// I HATE MYSELF
// Treat this as deprecated content.


namespace DeletedBlight.Projectiles.Melee
{
    public abstract class ModFlailProjectile : ModProjectile
    {
        protected virtual float MaxChainLength => 160f;
        protected virtual float MaxReturnDistance => 300f;
        protected virtual float ReturnSpeed => 14f;
        protected virtual float ReturnAcceleration => 0.9f;
        protected virtual int ReturnStartDistance => 60;
        protected virtual float MaxEscapeDistance => 2000f;
        protected virtual float IdleDragFactor => 0.9f;
        protected virtual float IdleGravity => 1f;
        protected virtual float SlowThreshold => 6f;
        protected virtual float SlowFallFactor => 0.2f;
        protected virtual float StationaryXDrag => 0.96f;

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            if (player.dead || Vector2.Distance(player.Center, Projectile.Center) > MaxEscapeDistance)
            {
                Projectile.Kill();
                return;
            }

            player.SetDummyItemTime(10);
            Projectile.direction = Projectile.Center.X > player.Center.X ? 1 : -1;
            player.ChangeDir(Projectile.direction);

            Vector2 mountedCenter = player.MountedCenter;
            Vector2 toPlayer = mountedCenter - Projectile.Center;
            float distance = toPlayer.Length();

            if (Projectile.ai[0] == 0f)
            {
                Projectile.tileCollide = true;
                if (distance > MaxChainLength)
                {
                    Projectile.ai[0] = 1f;
                    Projectile.netUpdate = true;
                }
                else if (!player.channel)
                {
                    if (Projectile.velocity.Y < 0f)
                    {
                        Projectile.velocity.Y *= 0.9f;
                    }

                    Projectile.velocity.Y += IdleGravity;
                    Projectile.velocity.X *= IdleDragFactor;
                }
            }
            else if (Projectile.ai[0] == 1f)
            {
                float meleeSpeed = player.inverseMeleeSpeed;
                float returnSpeed = ReturnSpeed / meleeSpeed;
                float returnAcceleration = ReturnAcceleration / meleeSpeed;
                float maxReturnDistance = MaxReturnDistance / meleeSpeed;
                int returnStartDistance = ReturnStartDistance;

                ModifyFlailReturn(ref returnSpeed, ref returnAcceleration, ref maxReturnDistance, ref returnStartDistance);

                if (Projectile.ai[1] == 1f)
                {
                    Projectile.tileCollide = false;
                }

                if (!player.channel || distance > maxReturnDistance || !Projectile.tileCollide)
                {
                    Projectile.ai[1] = 1f;
                    if (Projectile.tileCollide)
                    {
                        Projectile.netUpdate = true;
                    }

                    Projectile.tileCollide = false;
                    if (distance < 20f)
                    {
                        Projectile.Kill();
                        return;
                    }
                }

                if (!Projectile.tileCollide)
                {
                    returnAcceleration *= 2f;
                }

                if (distance > returnStartDistance || !Projectile.tileCollide)
                {
                    Vector2 targetVelocity = toPlayer / distance * returnSpeed;
                    Vector2 change = targetVelocity - Projectile.velocity;
                    float changeLength = change.Length();

                    if (changeLength > 0f)
                    {
                        change *= returnAcceleration / changeLength;
                    }

                    Projectile.velocity *= 0.98f;
                    Projectile.velocity += change;
                }
                else
                {
                    if (Math.Abs(Projectile.velocity.X) + Math.Abs(Projectile.velocity.Y) < SlowThreshold)
                    {
                        Projectile.velocity.X *= 0.96f;
                        Projectile.velocity.Y += SlowFallFactor;
                    }

                    if (player.velocity.X == 0f)
                    {
                        Projectile.velocity.X *= StationaryXDrag;
                    }
                }
            }

            Projectile.rotation = (float)Math.Atan2(toPlayer.Y, toPlayer.X) - Projectile.velocity.X * 0.1f;
            SpecialFlailAI(toPlayer, distance);
        }

        protected virtual void ModifyFlailReturn(ref float returnSpeed, ref float returnAcceleration, ref float maxReturnDistance, ref int returnStartDistance)
        {
        }

        protected virtual void SpecialFlailAI(Vector2 toPlayer, float distance)
        {
        }
    }
}
