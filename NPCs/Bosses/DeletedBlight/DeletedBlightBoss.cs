/*using Microsoft.Xna.Framework;
using ReLogic.Utilities;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Events;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace DeletedBlight.NPCs.Bosses.DeletedBlight;

[AutoloadBossHead]
public partial class DeletedBlightBoss : ModNPC
{
    #region Custom Types and Enumerations

    public enum AnimationState
    {
        Loop,
        Scream,
    }

    public enum DeletedBlightAIType
    {
        // Spawn animation behaviors
        CrashThroughScreen,
        IntroScreamAnimation,

        // Physical Attacks
        DemonicAssault,
        LeapofFaith,
        VesselsFolly,


        // Physical Projectile Attacks
        TurkeyTurnabout,
        Convergence,
        ShellShocker,
        Snowgrave,
        CANTESCAPE1,
        CANTESCAPE2,
        Trojan,


        // Magic Attacks
        LaserBarrage,
        OniObliteration,


        // Death animation
        DeathAnimation,
        GFB_StoryofUndertale,

        // Misc.
        Teleport,
        ResetCycle,
        
        // Useful count constant
        Count
    }

    #endregion Custom Types and Enumerations

    #region AI
    public override void AI()
    {
        foreach (Player player in Main.ActivePlayers)
        {
            if (player.dead)
                continue;

            player.wingTime = player.wingTimeMax;
        }

    }   
    #endregion AI
}
*/