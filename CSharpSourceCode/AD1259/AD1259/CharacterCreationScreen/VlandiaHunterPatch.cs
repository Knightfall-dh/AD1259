using System;
using System.Runtime.CompilerServices;
using HarmonyLib;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.CharacterCreationContent;

namespace AD1259.Patches
{
	#pragma warning disable BHA0001
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "VlandiaHunterNarrativeOptionOnCondition")]
	public class VlandiaHunterPatch
	{
		private static void Postfix(ref bool __result, CharacterCreationManager characterCreationManager)
		{
			bool flag = CustomCultureDefinitions.Ids.Contains(characterCreationManager.CharacterCreationContent.SelectedCulture.StringId);
			if (flag)
			{
				__result = true;
			}
		}
	}
	#pragma warning restore BHA0001
}
