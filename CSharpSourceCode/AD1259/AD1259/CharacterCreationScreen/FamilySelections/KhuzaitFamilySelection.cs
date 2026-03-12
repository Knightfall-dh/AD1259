using System;
using System.Runtime.CompilerServices;
using HarmonyLib;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.CharacterCreationContent;

namespace AD1259.Patches
{
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "KhuzaitRetainerNarrativeOptionOnCondition")]
	public class KhuzaitRetainerPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.KhuzaitCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "KhuzaitMerchantNarrativeOptionOnCondition")]
	public class KhuzaitMerchantPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.KhuzaitCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "KhuzaitHerderNarrativeOptionOnCondition")]
	public class KhuzaitHerderPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.KhuzaitCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "KhuzaitFarmerNarrativeOptionOnCondition")]
	public class KhuzaitFarmerPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.KhuzaitCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "KhuzaitHealerNarrativeOptionOnCondition")]
	public class KhuzaitHealerPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.KhuzaitCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "KhuzaitNomadHerderNarrativeOptionOnCondition")]
	public class KhuzaitNomadHerderPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.KhuzaitCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
}