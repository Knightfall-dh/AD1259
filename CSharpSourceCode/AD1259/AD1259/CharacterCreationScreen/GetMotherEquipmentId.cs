using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using HarmonyLib;
using TaleWorlds.CampaignSystem.CampaignBehaviors;

namespace AD1259.Patches
{
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "GetMotherEquipmentId")]
	public class MotherEquipmentPatch
	{
		private static void Postfix(ref string __result, string cultureId)
		{
			bool flag = CustomCultureDefinitions.CulturesWithOwnEquipmentsIds.Contains(cultureId);
			if (!flag)
			{
				string baseCulture;
				bool flag2 = !CultureMapUtil.TryGetBaseCulture(cultureId, out baseCulture) || string.IsNullOrEmpty(__result);
				if (!flag2)
				{
					string customSuffix = "_" + cultureId;
					bool flag3 = __result.Contains(customSuffix);
					if (flag3)
					{
						__result = __result.Replace(customSuffix, "_" + baseCulture);
					}
					else
					{
						foreach (string vanilla in CustomCultureDefinitions.VanillaBases)
						{
							Regex regex = new Regex("_" + vanilla + "\\b");
							bool flag4 = regex.IsMatch(__result);
							if (flag4)
							{
								__result = regex.Replace(__result, "_" + baseCulture, 1);
								break;
							}
						}
					}
				}
			}
		}
	}
}
