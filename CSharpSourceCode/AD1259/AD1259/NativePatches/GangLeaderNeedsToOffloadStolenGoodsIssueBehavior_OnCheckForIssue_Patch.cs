using System;
using System.Runtime.CompilerServices;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Issues;

namespace AD1259.Patches
{
	[HarmonyPatch(typeof(GangLeaderNeedsToOffloadStolenGoodsIssueBehavior), "OnCheckForIssue")]
	internal class GangLeaderNeedsToOffloadStolenGoodsIssueBehavior_OnCheckForIssue_Patch
	{
		public static bool Prefix(Hero hero)
		{
			bool flag = hero.CurrentSettlement != null && hero.CurrentSettlement.IsVillage && hero.IsGangLeader;
			return !flag;
		}
	}
}
