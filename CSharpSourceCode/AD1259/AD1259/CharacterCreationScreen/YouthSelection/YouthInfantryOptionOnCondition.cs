using System;
using System.Runtime.CompilerServices;
using HarmonyLib;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.CharacterCreationContent;

namespace AD1259.Patches
{
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "YouthInfantryOptionOnCondition")]
	public class YouthInfantryOptionOnConditionPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.AseraiCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
			bool flag2 = CustomCultureDefinitions.BattaniaCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag2)
			{
				__result = true;
			}
			bool flag3 = CustomCultureDefinitions.EmpireCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag3)
			{
				__result = true;
			}
			bool flag4 = CustomCultureDefinitions.KhuzaitCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag4)
			{
				__result = true;
			}
			bool flag5 = CustomCultureDefinitions.SturgiaCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag5)
			{
				__result = true;
			}
			bool flag6 = CustomCultureDefinitions.VlandiaCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag6)
			{
				__result = true;
			}
		}
	}
}
