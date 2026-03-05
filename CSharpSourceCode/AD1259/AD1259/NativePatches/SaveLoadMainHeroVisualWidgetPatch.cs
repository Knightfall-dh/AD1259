using HarmonyLib;
using SandBox.ViewModelCollection.SaveLoad;
using System;
using TaleWorlds.CampaignSystem.Extensions;
using TaleWorlds.Library;
using TaleWorlds.SaveSystem;

namespace AD1259.Patches
{
  [HarmonyPatch(typeof(SavedGameVM))]
  [HarmonyPatch(MethodType.Constructor, typeof(SaveGameFileInfo), typeof(bool), typeof(Action<SavedGameVM>), typeof(Action<SavedGameVM>), typeof(Action), typeof(Action), typeof(bool), typeof(bool))]
  public static class SavedGameVM_Constructor_Patch
  {
    public static void Postfix(SavedGameVM __instance, SaveGameFileInfo save)
    {
      try
      {
        if (string.IsNullOrEmpty(__instance.MainHeroVisualCode))
        {
          string characterVisualCode = save.MetaData.GetCharacterVisualCode();
          if (!string.IsNullOrEmpty(characterVisualCode))
            __instance.MainHeroVisualCode = characterVisualCode;
        }

        if (string.IsNullOrEmpty(__instance.BannerTextCode))
        {
          string clanBannerCode = save.MetaData.GetClanBannerCode();
          if (!string.IsNullOrEmpty(clanBannerCode))
            __instance.BannerTextCode = clanBannerCode;
        }
      }
      catch (Exception ex)
      {
        Debug.Print("[SavedGameVM_Constructor_Patch] Failed to restore hero visual code: " + ex.Message, 0, (Debug.DebugColor) 12, 17592186044416UL);
      }
    }
  }
}
