using HarmonyLib;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.View;


namespace AD1259.Patches
{
  internal class BannerTextureToMeshCrashPatch
  {
    [HarmonyPatch(typeof (AgentVisuals), "ApplyBannerTextureToMesh")]
    private static bool Prefix(AgentVisuals __instance, Mesh armorMesh, Texture bannerTexture)
    {
      bool flag;
      if (armorMesh == null)
      {
        Debug.Print("ApplyBannerTextureToMesh: armorMesh is NULL", 0, (Debug.DebugColor) 12, 17592186044416UL);
        flag = false;
      }
      else
      {
        string str = armorMesh.Name ?? "NULL";
        if (armorMesh.GetMaterial() == null)
        {
          Debug.Print("ApplyBannerTextureToMesh: GetMaterial() returned NULL  Mesh Name: " + str, 0, (Debug.DebugColor) 12, 17592186044416UL);
          flag = false;
        }
        else
          flag = true;
      }
      return flag;
    }
  }
}
