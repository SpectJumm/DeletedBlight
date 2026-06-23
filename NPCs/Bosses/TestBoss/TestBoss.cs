
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
            NPC.width = 100;
            NPC.height = 100;
            NPC.damage = 50;
            NPC.defense = 20;
            NPC.lifeMax = 5000;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = Item.buyPrice(0, 10, 0, 0);
            NPC.boss = true;
            NPC.knockBackResist = 0f;
            NPC.aiStyle = -1; // Custom AI
        }

        public override void AI() // For this first attack that I program, the boss will orbit around the player
        {
            Vector2 desiredPosition = Main.player[NPC.target].Center + new Vector2(200f, 0f).RotatedBy(MathHelper.ToRadians(NPC.ai[0]));
            NPC.Center = desiredPosition;
            
        }

        public override void OnKill()
        {
            // Logic for when the boss is defeated
        }
    }
}