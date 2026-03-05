using HarmonyLib;
using TaleWorlds.CampaignSystem.CampaignBehaviors;

namespace AD1259.Patches
{
    // No backstory for Calradia heroes
    [HarmonyPatch(typeof(BackstoryCampaignBehavior))]
    [HarmonyPatch("OnNewGameCreated")]
    public class BackstoryCampaignBehavior_OnNewGameCreated_Patch
    {
        public static bool Prefix()
        {
            return false;
        }
    }
}