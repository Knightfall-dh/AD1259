using System;
using System.Runtime.CompilerServices;
using HarmonyLib;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.CharacterCreationContent;

namespace AD1259.Patches
{
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "AdulthoodManhuntOptionOnCondition")]
	public class AdulthoodManhuntOptionOnConditionPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = OccupationUtil.IsUrbanOccupation(characterCreationManager.CharacterCreationContent.SelectedParentOccupation);
			if (flag)
			{
				__result = false;
			}
			else
			{
				bool flag2 = CustomCultureDefinitions.AseraiCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
				if (flag2)
				{
					__result = true;
				}
				bool flag3 = CustomCultureDefinitions.BattaniaCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
				if (flag3)
				{
					__result = true;
				}
				bool flag4 = CustomCultureDefinitions.EmpireCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
				if (flag4)
				{
					__result = true;
				}
				bool flag5 = CustomCultureDefinitions.KhuzaitCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
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
}
