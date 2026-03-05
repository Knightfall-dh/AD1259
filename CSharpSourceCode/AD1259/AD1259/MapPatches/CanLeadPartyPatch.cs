using HarmonyLib;
using TaleWorlds.CampaignSystem;


namespace AD1259.Patches
{
  [HarmonyPatch(typeof (Hero))]
  [HarmonyPatch("CanLeadParty")]
  public class CanLeadPartyPatch
  {
    public static void Postfix(ref bool __result, Hero __instance)
    {
      if (__instance == null || !__instance.IsLord || !__instance.IsFemale)
        return;
      __result = false;
    }
  }
}
