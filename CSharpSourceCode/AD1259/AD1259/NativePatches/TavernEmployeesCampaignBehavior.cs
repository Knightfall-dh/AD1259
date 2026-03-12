using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using SandBox.CampaignBehaviors;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.AgentOrigins;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.Issues;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace AD1259.Patches
{
	[HarmonyPatch(typeof(TavernEmployeesCampaignBehavior), "conversation_talk_bard_on_condition")]
	public static class TavernEmployeesCampaignBehavior_conversation_talk_bard_on_condition_Patch
	{
		[HarmonyPrefix]
		public static bool Prefix(ref bool __result)
		{
            bool flag = CharacterObject.OneToOneConversationCharacter?.Occupation == Occupation.Musician;
            bool result;
			if (flag)
			{
				List<string> list = new List<string>();
				List<Settlement> list2 = (from x in Settlement.All
				where x.IsTown && x != Settlement.CurrentSettlement
				select x).ToList<Settlement>();
				bool flag2 = list2.Count == 0;
				if (flag2)
				{
					__result = false;
					result = false;
				}
				else
				{
					Settlement settlement = list2[MBRandom.RandomInt(0, list2.Count)];
					MBTextManager.SetTextVariable("RANDOM_TOWN", settlement.Name, false);
					list.Add("{=3n1KRLpZ}'My love is far \n I know not where \n Perhaps the winds shall tell me'");
					list.Add("{=NQOQb0C9}'And many thousand bodies lay a-rotting in the sun \n But things like that must be you know for kingdoms to be won'");
					list.Add("{=bs8ayCGX}'A warrior brave you might surely be \n With your blade and your helm and your bold fiery steed \n But I'll give you a warning you'd be wise to heed \n Don't toy with the fishwives of {RANDOM_TOWN}'");
					list.Add("{=3n1KRLpZ}'My love is far \n I know not where \n Perhaps the winds shall tell me'");
					list.Add("{=YequZz6U}'Oh the maidens of {RANDOM_TOWN} are merry and fair \n Plotting their mischief with flowers in their hair \n Were I still a young man I sure would be there \n But now I'll take warmth over trouble'");
					list.Add("{=CM8Tr3lL}'Oh my pocket's been picked \n And my shirt's drenched with sick \n And my head feels like it's come a fit to bursting'");
					list.Add("{=DFkzQHRQ}'For all the silks of the Padishah \n For all the Emperor's gold \n For all the spice in the distance East...'");
					list.Add("{=2fbLBXtT}'O'er the whale-road she sped \n She were manned by the dead  \n And the clouds followed black in her wake'");
					string text = list[MBRandom.RandomInt(0, list.Count)];
					MBTextManager.SetTextVariable("LYRIC_SCRAP", new TextObject(text, null), false);
					__result = true;
					result = false;
				}
			}
			else
			{
				__result = false;
				result = false;
			}
			return result;
		}
	}
}
