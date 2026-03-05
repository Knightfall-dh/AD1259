using System;
using System.Runtime.CompilerServices;
using HarmonyLib;
using TaleWorlds.CampaignSystem.CampaignBehaviors;

namespace AD1259.Patches
{
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "GetFatherEquipmentId")]
	public class FatherEquipmentPatch
	{
		private static void Postfix(ref string __result, string cultureId)
		{
			bool flag = CustomCultureDefinitions.Ids.Contains(cultureId);
			if (flag)
			{
				foreach (string str in CustomCultureDefinitions.Ids)
				{
					__result = __result.Replace("_" + str, "_vlandia");
				}
			}
		}
	}
}