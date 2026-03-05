using System.Collections.Generic;
using HarmonyLib;
using psai.net;
using TaleWorlds.ModuleManager;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;

namespace AD1259.Patches
{
    [HarmonyPatch]
    public static class MBMusicManagerPatches
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(MBMusicManager), "Initialize")]
        public static void OverrideCreation()
        {
            if (NativeConfig.DisableSound)
            {
                return; // skip our custom loading if sound is disabled
            }

            string corePath = ModuleHelper.GetModuleFullPath("AD1259") + "music\\soundtrack.xml";

            // Optional: check if file actually exists before trying to load
            if (!System.IO.File.Exists(corePath))
            {
                // You could log this somewhere, e.g. via InformationManager or file logger
                // InformationManager.DisplayMessage(new InformationMessage("AD1259: soundtrack.xml not found at " + corePath, Colors.Red));
                return;
            }

            List<string> projectList = new List<string> { "AD1259" }; // or just use the full path directly if preferred

            PsaiResult pr = PsaiCore.Instance.LoadSoundtrackFromProjectFile(projectList);

            if (pr != PsaiResult.OK)
            {
                // Handle failure – at minimum log it so you know why your music isn't loading
                // InformationManager.DisplayMessage(new InformationMessage($"AD1259 music load failed: {pr}", Colors.Red));
                // You could also fall back to native loading here if desired
            }

            // Optional: if you want to completely prevent the original Initialize from running
            // return false;   ← uncomment only if you are sure you don't need vanilla music init
        }
    }
}