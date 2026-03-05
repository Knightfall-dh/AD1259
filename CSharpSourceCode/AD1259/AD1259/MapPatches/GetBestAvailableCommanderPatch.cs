using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;

namespace AD1259.Patches
{
  [HarmonyPatch(typeof (HeroSpawnCampaignBehavior))]
  [HarmonyPatch("GetBestAvailableCommander")]
  public class GetBestAvailableCommanderPatch
  {
    public static void Postfix(ref Hero __result)
    {
      if (__result == null)
        return;
      Hero hero = __result;
      if (hero.IsFemale && hero.IsLord && (hero.Clan == null || hero.Clan.Leader != hero && (hero.Clan.Kingdom == null || hero.Clan.Kingdom.Leader != hero)))
        __result = (Hero) null;
    }
  }
}
