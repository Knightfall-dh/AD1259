using System;
using System.Runtime.CompilerServices;
using HarmonyLib;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.CharacterCreationContent;

namespace AD1259.Patches
{
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "AdulthoodSavedVillageOptionOnCondition")]
	public class AdulthoodSavedVillageOptionOnConditionPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = !OccupationUtil.IsUrbanOccupation(characterCreationManager.CharacterCreationContent.SelectedParentOccupation) && CustomCultureDefinitions.SturgiaCultureIds.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
}
