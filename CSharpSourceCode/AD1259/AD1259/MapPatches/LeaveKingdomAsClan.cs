using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.BarterSystem.Barterables;

namespace AD1259.Patches
{
  internal class LeaveKingdomAsClanBarterablePatch
  {
    [HarmonyPrefix]
    [HarmonyPatch(typeof (LeaveKingdomAsClanBarterable), "Apply")]
    private static bool Fix(LeaveKingdomAsClanBarterable __instance)
    {
      Hero originalOwner = ((Barterable) __instance).OriginalOwner;
      return (originalOwner != null ? (object) originalOwner.Clan?.Kingdom : (object) null) != null;
    }
  }
}
