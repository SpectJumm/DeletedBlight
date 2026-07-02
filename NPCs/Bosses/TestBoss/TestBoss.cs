
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace DeletedBlight.NPCs.Bosses.TestBoss
{
    [AutoloadBossHead]


    public class TestBoss : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 1;
        }

        public override void SetDefaults()
        {
            NPC.width = 200;
            NPC.height = 200;
            NPC.damage = 50;
            NPC.defense = 20;
            NPC.lifeMax = 5000;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = Item.buyPrice(0, 10, 0, 0);
            NPC.boss = true;
            NPC.knockBackResist = 0f;
            NPC.aiStyle = -1; // Custom AI
            NPC.noTileCollide = true;
        }

        public override void AI() // Making a few functions that have different attacks in them
        {
            TurkeyTurnabout();
        }
        private void TurkeyTurnabout() {
            NPC.TargetClosest();
            NPC.ai[1]++;
            Player targetPlayer = Main.player[NPC.target]; // useful variable
            Vector2 directionToTarget = targetPlayer.Center - NPC.Center;
            directionToTarget.Normalize();
            Vector2 desiredPosition = targetPlayer.Center + new Vector2 (450f, 0f).RotatedBy(MathHelper.ToRadians(NPC.ai[1]*2.4f));
            NPC.Center = Vector2.Lerp(NPC.Center, desiredPosition, 0.5f);
            NPC.rotation = directionToTarget.ToRotation() - MathHelper.PiOver2; // Rotate the boss to face the player
            
            if (NPC.ai[1] % 45 == 0) // Every 45 ticks (0.75 seconds), shoot a projectile at the player
            {
                Vector2 shootDirection = directionToTarget * 10f; // Adjust the speed of the projectile
                Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, shootDirection, ProjectileID.EyeLaser, 20, 1f, Main.myPlayer);
                SoundEngine.PlaySound(SoundID.Item12, NPC.position); // Play a shooting sound
            }
        }

        public override void OnKill()
        {
            // Logic for when the boss is defeated
        }
    }
}