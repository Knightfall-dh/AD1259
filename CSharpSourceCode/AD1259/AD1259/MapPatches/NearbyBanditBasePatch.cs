using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Issues;
using TaleWorlds.CampaignSystem.Settlements;


namespace AD1259.Patches
{
  [HarmonyPatch]
  public class NearbyBanditBaseIssueBehavior_ConditionsHold_Patch
  {
    [HarmonyPrefix]
    [HarmonyPatch(typeof (NearbyBanditBaseIssueBehavior), "ConditionsHold")]
    private static bool ConditionsHoldPrefix(Hero issueGiver, ref bool __result)
    {
      bool flag;
      try
      {
        object obj;
        if (issueGiver == null)
        {
          obj = (object) null;
        }
        else
        {
          Settlement currentSettlement = issueGiver.CurrentSettlement;
          if (currentSettlement == null)
          {
            obj = (object) null;
          }
          else
          {
            Village village = currentSettlement.Village;
            obj = village != null ? (object) village.Bound?.Town : (object) null;
          }
        }
        if (obj == null)
        {
          __result = false;
          flag = false;
        }
        else
          flag = true;
      }
      catch (Exception ex)
      {
        __result = false;
        flag = false;
      }
      return flag;
    }
  }
}
