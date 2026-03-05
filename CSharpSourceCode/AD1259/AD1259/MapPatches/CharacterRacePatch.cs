using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace AD1259.Patches
{
  [HarmonyPatch(typeof (CharacterObject), "CreateFrom")]
  public static class CharacterCodePatch
  {
    [HarmonyPostfix]
    public static void CharacterRacePatch(ref CharacterObject __result, CharacterObject character) => ((BasicCharacterObject) __result).Race = ((BasicCharacterObject) character).Race;
  }
}
