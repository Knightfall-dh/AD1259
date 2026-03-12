using System;
using TaleWorlds.CampaignSystem.Party;

namespace AD1259.Patches
{
	public static class HocamGrupIndirimiVarMiPatch
	{
		public static void Postfix(ref int __result)
		{
			__result = 100 * MobileParty.MainParty.Party.NumberOfHealthyMembers;
		}
	}
}
