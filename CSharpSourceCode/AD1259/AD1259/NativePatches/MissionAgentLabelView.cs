using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace AD1259.Patches
{
    [HarmonyPatch(typeof(MissionAgentLabelView), "InitAgentLabel")]
    public static class MissionAgentLabelView_InitAgentLabel
    {
        public static void Prefix(Agent agent, ref Banner peerBanner)
        {
            if (agent?.Character?.Culture?.Banner != null)
            {
                peerBanner = agent.Character.Culture.Banner;
            }
        }
    }
}