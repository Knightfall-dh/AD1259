using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;


namespace AD1259.Patches
{
  [HarmonyPatch(typeof (GameStateManager), "CleanAndPushState")]
  public class CampaignIntroSkipPatch
  {
    public static void Prefix(GameState gameState)
    {
      if (!(gameState is VideoPlaybackState videoPlaybackState) || !videoPlaybackState.VideoPath.Contains("campaign_intro"))
        return;
      AccessTools.Property(typeof (VideoPlaybackState), "AudioPath").SetValue((object) videoPlaybackState, (object) null);
    }

    public static void Postfix(GameState gameState)
    {
      if (!(gameState is VideoPlaybackState videoPlaybackState) || !videoPlaybackState.VideoPath.Contains("campaign_intro"))
        return;
      videoPlaybackState.OnVideoFinished();
    }
  }
}
