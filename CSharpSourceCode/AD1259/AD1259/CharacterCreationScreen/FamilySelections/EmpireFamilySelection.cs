using System;
using System.Runtime.CompilerServices;
using HarmonyLib;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.CharacterCreationContent;

namespace AD1259.Patches
{
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "EmpireLandlordNarrativeOptionOnCondition")]
	public class EmpireLandlordPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.EmpireCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "EmpireUrbanNarrativeOptionOnCondition")]
	public class EmpireUrbanPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.EmpireCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "EmpireFarmerNarrativeOptionOnCondition")]
	public class EmpireFarmerPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.EmpireCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "EmpireArtisanNarrativeOptionOnCondition")]
	public class EmpireArtisanPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.EmpireCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "EmpireHunterNarrativeOptionOnCondition")]
	public class EmpireHunterPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.EmpireCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "EmpireVagabondNarrativeOptionOnCondition")]
	public class EmpireVagabondPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.EmpireCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
}
