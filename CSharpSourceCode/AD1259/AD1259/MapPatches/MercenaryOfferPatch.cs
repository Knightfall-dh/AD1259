using HarmonyLib;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;

namespace AD1259.Patches
{
  public static class MercenaryOfferPatch
  {
    [HarmonyPrefix]
    [HarmonyPatch(typeof (VassalAndMercenaryOfferCampaignBehavior), "VassalKingdomSelectionConditionsHold")]
    public static bool MercenaryOfferPatch_1(Kingdom kingdom, ref bool __result)
    {
      if (!kingdom.IsEliminated && kingdom.Leader != null && kingdom.Leader.IsActive)
        return true;
      __result = false;
      return false;
    }

    [HarmonyPrefix]
    [HarmonyPatch(typeof (VassalAndMercenaryOfferCampaignBehavior), "MercenaryKingdomSelectionConditionsHold")]
    public static bool MercenaryOfferPatch_2(Kingdom kingdom, ref bool __result)
    {
      if (!kingdom.IsEliminated && kingdom.Leader != null && kingdom.Leader.IsActive)
        return true;
      __result = false;
      return false;
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof (VassalAndMercenaryOfferCampaignBehavior), "ClearKingdomOffer")]
    public static void MercenaryOfferPatch_3(
      Kingdom kingdom,
      Dictionary<Kingdom, CampaignTime> ____vassalOffers)
    {
      if (!____vassalOffers.ContainsKey(kingdom))
        return;
      ____vassalOffers.Remove(kingdom);
    }
  }
}
