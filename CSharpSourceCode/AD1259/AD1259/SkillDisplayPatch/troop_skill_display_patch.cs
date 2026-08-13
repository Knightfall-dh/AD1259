using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Extensions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace AD1259.Patches
{
    [HarmonyPatch(typeof(TooltipRefresherCollection), "RefreshCharacterTooltip")]
    public static class RefreshCharacterTooltip_Top5Skills_Patch
    {
        public static bool Prefix(PropertyBasedTooltipVM propertyBasedTooltipVM, object[] args)
        {
            if (propertyBasedTooltipVM == null || args == null || args.Length == 0)
                return true; // let original run

            CharacterObject character = args[0] as CharacterObject;
            if (character == null)
                return true;

            // ----- Rebuild the tooltip ourselves -----
            propertyBasedTooltipVM.Mode = 1;

            // Title
            propertyBasedTooltipVM.AddProperty("", character.Name.ToString(), 0, TooltipProperty.TooltipPropertyFlags.Title);

            // Tier
            TextObject tierText = GameTexts.FindText("str_party_troop_tier");
            tierText.SetTextVariable("TIER_LEVEL", character.Tier);
            propertyBasedTooltipVM.AddProperty("", tierText.ToString());

            // Required XP to upgrade (if any)
            if (character.UpgradeTargets.Length != 0)
            {
                GameTexts.SetVariable("XP_AMOUNT", character.GetUpgradeXpCost(PartyBase.MainParty, 0));
                propertyBasedTooltipVM.AddProperty("", GameTexts.FindText("str_required_xp_to_upgrade").ToString());
            }

            // Daily wage
            if (character.TroopWage > 0)
            {
                GameTexts.SetVariable("LEFT", GameTexts.FindText("str_wage"));
                GameTexts.SetVariable("STR1", character.TroopWage);
                GameTexts.SetVariable("STR2", "{=!}<img src=\"General\\Icons\\Coin@2x\" extend=\"6\">");
                GameTexts.SetVariable("RIGHT", GameTexts.FindText("str_STR1_space_STR2"));
                propertyBasedTooltipVM.AddProperty("", GameTexts.FindText("str_LEFT_colon_RIGHT_wSpaceAfterColon").ToString());
            }

            // Skills header
            propertyBasedTooltipVM.AddProperty("", "");
            propertyBasedTooltipVM.AddProperty("", GameTexts.FindText("str_skills").ToString());
            propertyBasedTooltipVM.AddProperty("", "", 0, TooltipProperty.TooltipPropertyFlags.RundownSeperator);

            // Only the 5 highest skills
            var topSkills = Skills.All
                .Select(skill => new { Skill = skill, Value = character.GetSkillValue(skill) })
                .Where(x => x.Value > 0)
                .OrderByDescending(x => x.Value)
                .Take(5);

            foreach (var entry in topSkills)
            {
                propertyBasedTooltipVM.AddProperty(entry.Skill.Name.ToString(), entry.Value.ToString());
            }

            return false; // skip original method
        }
    }
}