using HarmonyLib;
using SandBox;
using SandBox.AdvancedStartOptions;
using SandBox.View;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.AdvancedStartOptions;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ScreenSystem;

namespace AD1259.Patches
{
    [HarmonyPatch]
    public static class DisableAdvancedStartingOptionsPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(AdvancedStartOptionsManager), nameof(AdvancedStartOptionsManager.CreateCampaignStartOptions))]
        private static bool CreateCampaignStartOptions_Prefix(ref AdvancedStartOptions __result)
        {
            __result = new AdvancedStartOptions(); // empty → IsEmpty() == true
            return false; // skip original
        }
        [HarmonyPrefix]
        [HarmonyPatch(typeof(SandBoxViewSubModule), "OnBeforeInitialModuleScreenSetAsRoot")]
        private static bool OnBeforeInitialModuleScreenSetAsRoot_Prefix(SandBoxViewSubModule __instance)
        {
            var field = AccessTools.Field(typeof(SandBoxViewSubModule), "_startingOptionsCache");
            field?.SetValue(__instance, null);
            return true; // still run the original method
        }
    }
}