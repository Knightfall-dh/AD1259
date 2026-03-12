using System;
using System.Runtime.CompilerServices;
using HarmonyLib;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.CharacterCreationContent;

namespace AD1259.Patches
{
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "VlandiaRetainerNarrativeOptionOnCondition")]
	public class VlandiaRetainerPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.VlandiaCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "VlandiaMerchantNarrativeOptionOnCondition")]
	public class VlandiaMerchantPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.VlandiaCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "VlandiaFarmerNarrativeOptionOnCondition")]
	public class VlandiaFarmerPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.VlandiaCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "VlandiaBlacksmithNarrativeOptionOnCondition")]
	public class VlandiaBlacksmithPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.VlandiaCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "VlandiaHunterNarrativeOptionOnCondition")]
	public class VlandiaHunterPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.VlandiaCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "VlandiaMercenaryNarrativeOptionOnCondition")]
	public class VlandiaMercenaryPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.VlandiaCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
}
