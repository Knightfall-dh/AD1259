using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.ModuleManager;

namespace AD1259.Patches
{
  [HarmonyPatch(typeof (Campaign), "InitializeScenes")]
  public class Campaign_InitializeScenes_Patch
  {
    public static bool Prefix()
    {
      GameSceneDataManager.Instance.LoadSPBattleScenes(ModuleHelper.GetModuleFullPath("AD1259") + "ModuleData/sp_battle_scenes.xml");
      GameSceneDataManager.Instance.LoadConversationScenes(ModuleHelper.GetModuleFullPath("Sandbox") + "ModuleData/conversation_scenes.xml");
      GameSceneDataManager.Instance.LoadMeetingScenes(ModuleHelper.GetModuleFullPath("Sandbox") + "ModuleData/meeting_scenes.xml");
      return false;
    }
  }
}
