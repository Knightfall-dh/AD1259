using System;
using HarmonyLib;
using SandBox.CampaignBehaviors;
using TaleWorlds.CampaignSystem;

namespace AD1259.Patches
{
	[HarmonyPatch(typeof(GuardsCampaignBehavior), "conversation_guard_start_on_condition")]
	public class ConversationGuardStartPatch
	{
		public static bool Prefix(ref bool __result)
		{
			bool flag = Hero.MainHero.CurrentSettlement != null && Hero.MainHero.CurrentSettlement.IsHideout;
			bool result;
			if (flag)
			{
				__result = false;
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}
	}
}
