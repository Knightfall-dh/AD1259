using HarmonyLib;
using TaleWorlds.MountAndBlade;

namespace AD1259.Patches
{
  [HarmonyPatch(typeof (SiegeLadder), "OnFormationFrameChanged")]
  public class SiegeLadderNullPatch
  {
    private static bool Prefix(LadderQueueManager ____queueManagerForAttackers) => ____queueManagerForAttackers != null;
  }
}
