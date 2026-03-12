using System;
using System.Runtime.CompilerServices;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Issues;
using TaleWorlds.CampaignSystem.Settlements;

namespace AD1259.Patches
{
	[HarmonyPatch]
	public class HeadmanVillageNeedsDraughtAnimalsIssueBehavior_ConditionsHold_Patch
	{
		[HarmonyPrefix]
		[HarmonyPatch(typeof(HeadmanVillageNeedsDraughtAnimalsIssueBehavior), "ConditionsHold")]
		private static bool ConditionsHoldPrefix(Hero issueGiver, ref bool __result)
		{
			bool result;
			try
			{
				object obj;
				if (issueGiver == null)
				{
					obj = null;
				}
				else
				{
					Settlement currentSettlement = issueGiver.CurrentSettlement;
					if (currentSettlement == null)
					{
						obj = null;
					}
					else
					{
						Village village = currentSettlement.Village;
						if (village == null)
						{
							obj = null;
						}
						else
						{
							Settlement bound = village.Bound;
							obj = ((bound != null) ? bound.Town : null);
						}
					}
				}
				bool flag = obj == null;
				if (flag)
				{
					__result = false;
					result = false;
				}
				else
				{
					result = true;
				}
			}
			catch (Exception ex)
			{
				__result = false;
				result = false;
			}
			return result;
		}
	}
}
