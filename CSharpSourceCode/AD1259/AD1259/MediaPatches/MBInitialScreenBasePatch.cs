using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;


namespace AD1259.Patches
{
  [HarmonyPatch(typeof (MBInitialScreenBase), "RefreshScene")]
  public class RefreshScenePatch
  {
    [HarmonyPrefix]
    private static bool Prefix(MBInitialScreenBase __instance)
    {
      try
      {
        Traverse.Create((object) __instance).Field("_isPlayingVideo").SetValue((object) false);
        Traverse traverse = Traverse.Create((object) __instance).Field("_videoPlayerView");
        VideoPlayerView videoPlayerView1 = traverse.GetValue<VideoPlayerView>();
        if (videoPlayerView1 != null)
        {
          videoPlayerView1.StopVideo();
          videoPlayerView1.FinalizePlayer();
          traverse.SetValue((object) null);
        }
        VideoPlayerView videoPlayerView2 = VideoPlayerView.CreateVideoPlayerView();
        traverse.SetValue((object) videoPlayerView2);
        List<KeyValuePair<string, string>> keyValuePairList = new List<KeyValuePair<string, string>>();
        string path = System.IO.Path.Combine(BasePath.Name, "Modules/AD1259/Videos/initial_menu");
        if (Directory.Exists(path))
        {
          string searchPattern = "*_pc.ivf";
          foreach (string directory in Directory.GetDirectories(path))
          {
            string[] files1 = Directory.GetFiles(directory, "*.ogg");
            string[] files2 = Directory.GetFiles(directory, searchPattern);
            if (files1.Length != 0 && files2.Length != 0)
              keyValuePairList.Add(new KeyValuePair<string, string>(files2[0], files1[0]));
          }
        }
        float num = 24f;
        string empty1 = string.Empty;
        string empty2 = string.Empty;
        if (keyValuePairList.Count > 0)
        {
          int index = new Random(DateTime.Now.Second).Next(keyValuePairList.Count);
          KeyValuePair<string, string> keyValuePair = keyValuePairList[index];
          string key = keyValuePair.Key;
          keyValuePair = keyValuePairList[index];
          string str = keyValuePair.Value;
          videoPlayerView2.PlayVideo(key, str, num, true);
          Traverse.Create((object) __instance).Field("_isPlayingVideo").SetValue((object) true);
        }
        Vec2 screenResolution = MBWindowManager.GetScreenResolution();
        AccessTools.Method(typeof (MBInitialScreenBase), "RefreshVideoAspect", (Type[]) null, (Type[]) null).Invoke((object) __instance, new object[1]
        {
          (object) screenResolution
        });
        return false;
      }
      catch (Exception ex)
      {
        Debug.Print("Exception in RefreshScene prefix: " + ex.Message + "\n" + ex.StackTrace, 0, (Debug.DebugColor) 12, 17592186044416UL);
        return true;
      }
    }
  }
}
