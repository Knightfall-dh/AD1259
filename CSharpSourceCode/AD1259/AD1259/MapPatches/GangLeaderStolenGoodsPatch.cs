using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Issues;
using TaleWorlds.CampaignSystem.Settlements;


namespace AD1259.Patches
{
  internal class GangLeadersStolenGoodsPatch
  {
    [HarmonyPatch(typeof (GangLeaderNeedsToOffloadStolenGoodsIssueBehavior), "OnCheckForIssue")]
    public static bool Prefix(Hero hero) => hero.CurrentSettlement == null || !hero.CurrentSettlement.IsVillage || !hero.IsGangLeader;

    [HarmonyPatch(typeof (GangLeaderNeedsToOffloadStolenGoodsIssueBehavior), "ConditionsHold")]
    public static bool Prefix(Hero issueGiver, out Settlement selectedHideout, ref bool __result)
    {
      selectedHideout = (Settlement) null;
      bool flag;
      if ((issueGiver != null ? (object) issueGiver.CurrentSettlement?.Town : (object) null) == null)
      {
        __result = false;
        flag = false;
      }
      else
        flag = true;
      return flag;
    }
  }
}
