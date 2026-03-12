using System;
using System.Runtime.CompilerServices;
using HarmonyLib;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.CharacterCreationContent;

namespace AD1259.Patches
{
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "AseraiKinsfolkNarrativeOptionOnCondition")]
	public class AseraiKinsfolkPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.AseraiCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "AseraiSlaveNarrativeOptionOnCondition")]
	public class AseraiSlavePatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.AseraiCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "AseraiPhysicianNarrativeOptionOnCondition")]
	public class AseraiPhysicianPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.AseraiCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "AseraiFarmerNarrativeOptionOnCondition")]
	public class AseraiFarmerPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.AseraiCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "AseraiHerderNarrativeOptionOnCondition")]
	public class AseraiHerderPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.AseraiCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "AseraiArtisanNarrativeOptionOnCondition")]
	public class AseraiArtisanPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.AseraiCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
	
}
