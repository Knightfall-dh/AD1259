using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.Library;


namespace AD1259.Patches
{
  public static class TotalWar
  {
    [CommandLineFunctionality.CommandLineArgumentFunction("start_player_vs_world_war", "campaign")]
    public static string StartPlayerVsWorldWar(List<string> strings)
    {
      if (!CampaignCheats.CheckCheatUsage(ref CampaignCheats.ErrorType))
        return CampaignCheats.ErrorType;
      if (CampaignCheats.CheckHelp(strings))
        return "Format is \"campaign.start_player_vs_world_war\". Declares war on every faction currently at peace with the player.";
      if (Campaign.Current == null)
        return "No campaign is running.";
      IFaction mapFaction = Clan.PlayerClan.MapFaction;
      int num = 0;
      List<IFaction> ifactionList = new List<IFaction>();
      ifactionList.AddRange(((IEnumerable) Campaign.Current.Kingdoms).Cast<IFaction>());
      ifactionList.AddRange(((IEnumerable<Clan>) Clan.All).Where<Clan>((Func<Clan, bool>) (c => c.Kingdom == null && !c.IsBanditFaction && c != Clan.PlayerClan)).Cast<IFaction>());
      foreach (IFaction ifaction in ifactionList)
      {
        if (ifaction != mapFaction && !ifaction.IsEliminated && !FactionManager.IsAtWarAgainstFaction(mapFaction, ifaction))
        {
          DeclareWarAction.ApplyByDefault(mapFaction, ifaction);
          ++num;
        }
      }
      return num > 0 ? string.Format("War declared against {0} faction(s). Player is now at war with the world.", (object) num) : "Player is already at war with everyone.";
    }
  }
}
