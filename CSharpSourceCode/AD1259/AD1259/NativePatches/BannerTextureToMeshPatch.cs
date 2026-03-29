using System;
using HarmonyLib;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.Screens;

namespace AD1259.Patches
{
    // Patch for MissionScreen
    [HarmonyPatch(typeof(MissionScreen), "ApplyBannerTextureToMesh")]
    public static class MissionScreen_ApplyBannerTexture_Debug
    {
        public static bool Prefix(Mesh armorMesh, Texture bannerTexture)
        {
            if (armorMesh == null)
            {
                return false;
            }

            Material baseMaterial = armorMesh.GetMaterial();

            if (baseMaterial == null)
            {
                return false;
            }

            return true;
        }
    }

    // Patch for AgentVisuals
    [HarmonyPatch(typeof(AgentVisuals), "ApplyBannerTextureToMesh")]
    public static class AgentVisuals_ApplyBannerTexture_Debug
    {
        public static bool Prefix(AgentVisuals __instance, Mesh armorMesh, Texture bannerTexture)
        {
            if (armorMesh == null)
            {
                return false;
            }

            Material baseMaterial = armorMesh.GetMaterial();

            if (baseMaterial == null)
            {
                return false;
            }

            return true;
        }
    }
}