using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using ReLogic.Content;
using Terraria;
using DeletedBlight.Rarities;
using DeletedBlight.Sounds;
using DeletedBlight.Items.Dyes;
using DeletedBlight.Assets;

namespace DeletedBlight
{
	// Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
	public class DeletedBlight : Mod
	{
		public override void Load()
		{
			if (Main.netMode != NetmodeID.Server)
			{
				// This is where we load our shader, and add it to the filter.

				Asset<Effect> dyeShader = Assets.Request<Effect>("Assets/AutoloadedEffects/Shaders/Dyes/FirstShader");

				// To add a dye, add this line for every dye you want to add, changing the name and the shader used.
				// Reference the corresponding name of your pass in the technique for the last parameter. In this case, it's ArmorNoise.
				GameShaders.Armor.BindShader(ModContent.ItemType<FirstDye>(), new ArmorShaderData(dyeShader, "ArmorNoise"));

				// If your dye takes specific parameters such as color, you can append them after binding the shader.
				// Reference https://github.com/tModLoader/tModLoader/wiki/Expert-Shader-Guide if you get stuck.

				Asset<Effect> chromaticAberration = Assets.Request<Effect>("Assets/AutoloadedEffects/Shaders/OverlayModifiers/ChromaticAberration");
				// GameShaders.Misc.BindShader(ModContent.RarityType<BlightGreen>(), new MiscShaderData(chromaticAberration, "ChromaticAberration"));
				// Commenting this code out because I'm too stupid to make it work. ;-;
				GameShaders.Armor.BindShader(ModContent.ItemType<TestDye>(), new ArmorShaderData(chromaticAberration, "ChromaticAberration"));
				

			}
		}
	}
}
