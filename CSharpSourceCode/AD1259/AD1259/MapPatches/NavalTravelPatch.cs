using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using HarmonyLib;
using SandBox;
using SandBox.View.Map;
using SandBox.View.Map.Visuals;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Map;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.View;

namespace AD1259.Patches
{
    public class NavalTravelPatch
    {
        [HarmonyPatch(typeof(MobilePartyVisual), "Tick")]
        // MODIFIED & FIXED BY SHINYA (Discord: shinya8941)
        public class MapScenePatchSingle
        {
            [HarmonyPostfix]
            public static void Postfix(MobilePartyVisual __instance)
            {
                try
                {
                    GameEntity strategicEntity = __instance.StrategicEntity;
                    MobileParty mobileParty = __instance.MapEntity.MobileParty;
                    IMapScene mapSceneWrapper = Campaign.Current.MapSceneWrapper;
                    CampaignVec2 position = mobileParty.Position;

                    if (mapSceneWrapper.GetTerrainTypeAtPosition(position) == TerrainType.Fording && strategicEntity.ChildCount == 0)
                    {
                        MatrixFrame identity = MatrixFrame.Identity;
                        var gameEntity = GameEntity.CreateEmpty(strategicEntity.Scene, true, true, true);
                        string metaMeshName = "ship_a";
                        Hero leaderHero = mobileParty.LeaderHero;
                        string text;

                        if (leaderHero == null)
                        {
                            text = null;
                        }
                        else
                        {
                            Banner clanBanner = leaderHero.ClanBanner;
                            text = ((clanBanner != null) ? clanBanner.Serialize() : null);
                        }

                        string value = text;
                        identity.rotation.ApplyScaleLocal(0.15f);
                        gameEntity.SetFrame(ref identity, true);
                        gameEntity.AddMultiMesh(MetaMesh.GetCopy(metaMeshName, true, false), true); // the ship mesh is attached here
                        bool flag2 = !string.IsNullOrEmpty(value);

                        try
                        {
                            strategicEntity.AddChild(gameEntity, false); // the ship entity is added into game scene
                        }
                        catch (AccessViolationException ave)
                        {
                            MBDebug.Print("Naval Patch Error at: Line 444 (AccessViolationException)");
                            Trace.WriteLine("Naval Patch Error at: Line 444 (AccessViolationException)");
                        }
                        catch (Exception ex)
                        {
                            MBDebug.Print("Naval Patch Error at: Line 448");
                        }

                        AgentVisuals humanAgentVisuals = __instance.HumanAgentVisuals;
                        if (humanAgentVisuals != null)
                        {
                            humanAgentVisuals.Reset();
                        }

                        AgentVisuals mountAgentVisuals = __instance.MountAgentVisuals;
                        if (mountAgentVisuals != null)
                        {
                            mountAgentVisuals.Reset();
                        }

                        AgentVisuals caravanMountAgentVisuals = __instance.CaravanMountAgentVisuals;
                        if (caravanMountAgentVisuals != null)
                        {
                            caravanMountAgentVisuals.Reset();
                        }

                        AccessTools.Property(typeof(MobilePartyVisual), "HumanAgentVisuals").SetValue(__instance, null);
                        AccessTools.Property(typeof(MobilePartyVisual), "MountAgentVisuals").SetValue(__instance, null);
                        AccessTools.Property(typeof(MobilePartyVisual), "CaravanMountAgentVisuals").SetValue(__instance, null);
                    }
                    else if (mapSceneWrapper.GetTerrainTypeAtPosition(position) != TerrainType.Fording && strategicEntity.ChildCount > 0)
                    {
                        mobileParty.Party.SetVisualAsDirty();
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
            }
        }

        [HarmonyPatch(typeof(MapScreen), "StepSounds")]
        public class StepSoundsPatch
        {
            [HarmonyPrefix]
            public static bool Prefix(MobileParty party)
            {
                return Campaign.Current.MapSceneWrapper.GetFaceTerrainType(party.CurrentNavigationFace) != TerrainType.Fording;
            }
        }

        [HarmonyPatch(typeof(MapScene), "GetFaceTerrainType")]
        public class GetFaceTerrainTypePatch
        {
            [HarmonyPostfix]
            public static void Postfix1(PathFaceRecord navMeshFace, MapScene __instance, ref TerrainType __result)
            {
                bool flag = navMeshFace.IsValid() && __instance.Scene.GetIdOfNavMeshFace(navMeshFace.FaceIndex) == 9;
                if (flag)
                {
                    __result = TerrainType.Fording;
                }
            }
        }

        [HarmonyPatch(typeof(MapScene), "GetHeightAtPoint")]
        public class GetHeightAtPointPatch
        {
            [HarmonyPostfix]
            public static void GetTerrainHeightPatch(MapScene __instance, CampaignVec2 point, ref float height)
            {
                height = MathF.Max(height, __instance.Scene.GetWaterLevel());
            }
        }
    }
}
