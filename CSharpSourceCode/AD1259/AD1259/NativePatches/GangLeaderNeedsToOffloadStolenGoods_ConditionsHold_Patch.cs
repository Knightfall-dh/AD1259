using System;
using System.Runtime.CompilerServices;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Issues;
using TaleWorlds.CampaignSystem.Settlements;

namespace AD1259.Patches
{
	[HarmonyPatch(typeof(GangLeaderNeedsToOffloadStolenGoodsIssueBehavior), "ConditionsHold")]
	public static class GangLeaderNeedsToOffloadStolenGoods_ConditionsHold_Patch
	{
		public static bool Prefix(Hero issueGiver, out Settlement selectedHideout, ref bool __result)
		{
			selectedHideout = null;
			object obj;
			if (issueGiver == null)
			{
				obj = null;
			}
			else
			{
				Settlement currentSettlement = issueGiver.CurrentSettlement;
				obj = ((currentSettlement != null) ? currentSettlement.Town : null);
			}
			bool flag = obj == null;
			bool result;
			if (flag)
			{
				__result = false;
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}
	}
}
