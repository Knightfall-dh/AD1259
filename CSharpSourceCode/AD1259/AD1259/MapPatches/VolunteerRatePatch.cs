using HarmonyLib;
using Helpers;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;


namespace AD1259.Patches
{
        [HarmonyPatch]
        public class IncreaseVolunteerRate
        {
            [HarmonyPrefix]
            [HarmonyPatch(typeof(DefaultVolunteerModel), "GetDailyVolunteerProductionProbability")]
            private static bool Prefix(Hero hero, int index, Settlement settlement, ref float __result)
            {
                float num = 2f;
                int num2 = 0;
                foreach (Town town in hero.CurrentSettlement.MapFaction.Fiefs)
                {
                    num2 += (town.IsTown ? (((town.Prosperity < 3000f) ? 2 : ((town.Prosperity < 6000f) ? 3 : 4)) + town.Villages.Count) : town.Villages.Count);
                }
                //float num3 = (num2 < 46) ? ((float)num2 / 46f * ((float)num2 / 46f)) : 1f;
                // Instead of quadratic formulae, using a softer formula here to give smaller factions more recruits 
                float num3 = (num2 < 46) ? ((float)num2 / 46f) : 1f;

                // If kingdom has less than 6 fiefs, give a baseline of 0.5 recruits
                if (num2 < 4)
                {
                    num3 = (num2 < 46) ? (0.5f + 0.5f * ((float)num2 / 46f)) : 1f;
                }

                // If kingdom has less than 3 fiefs, give 1.2 bonus to recruits
                if (num2 < 2)
                {
                    num3 = (num2 < 46) ? (1.2f - (float)num2 / 46f) : 1f;
                }

                num += ((hero.CurrentSettlement != null && num3 < 1f) ? ((1f - num3) * 0.25f) : 0f);
                float baseNumber = 2f * MathF.Clamp(MathF.Pow(num, (float)(index + 1)), 0f, 1f);
                ExplainedNumber explainedNumber = new ExplainedNumber(baseNumber, false, null);
                Clan clan = hero.Clan;
                bool flag = ((clan != null) ? clan.Kingdom : null) != null && clan.Kingdom.ActivePolicies.Contains(DefaultPolicies.Cantons);
                if (flag)
                {
                    explainedNumber.AddFactor(0.3f, null);
                }
                Town town2;
                if (!settlement.IsTown)
                {
                    Settlement tradeBound = settlement.Village.TradeBound;
                    town2 = ((tradeBound != null) ? tradeBound.Town : null);
                }
                else
                {
                    town2 = settlement.Town;
                }
                Town town3 = town2;
                bool flag2 = town3 != null && hero.IsAlive && hero.VolunteerTypes[index] != null && hero.VolunteerTypes[index].IsMounted;
                if (flag2)
                {
                    bool perkValueForTown = PerkHelper.GetPerkValueForTown(DefaultPerks.Riding.CavalryTactics, town3);
                    if (perkValueForTown)
                    {
                        explainedNumber.AddFactor(DefaultPerks.Riding.CavalryTactics.PrimaryBonus, null);
                    }
                }
                __result = explainedNumber.ResultNumber;
                return false;
            }
            public IncreaseVolunteerRate()
            {
            }
        }
}
