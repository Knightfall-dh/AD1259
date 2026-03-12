using System;
using System.Runtime.CompilerServices;
using HarmonyLib;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.CharacterCreationContent;

namespace AD1259.Patches
{
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "BattaniaRetainerNarrativeOptionOnCondition")]
	public class BattaniaRetainerPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.BattaniaCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "BattaniaHealerNarrativeOptionOnCondition")]
	public class BattaniaHealerPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.BattaniaCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "BattaniaFarmerNarrativeOptionOnCondition")]
	public class BattaniaFarmerPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.BattaniaCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "BattaniaArtisanNarrativeOptionOnCondition")]
	public class BattaniaArtisanPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.BattaniaCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "BattaniaHunterNarrativeOptionOnCondition")]
	public class BattaniaHunterPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.BattaniaCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "BattaniaBardNarrativeOptionOnCondition")]
	public class BattaniaBardPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.BattaniaCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
}