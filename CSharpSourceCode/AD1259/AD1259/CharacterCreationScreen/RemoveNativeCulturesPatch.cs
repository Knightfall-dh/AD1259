using HarmonyLib;
using System;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.CampaignSystem.ViewModelCollection.CharacterCreation;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace AD1259.Patches
{
    // Add only the cultures listed in CustomCultureDefinitions to the selection screen and skip the original method
    [HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "InitializeCharacterCreationCultures")]
    public class AddOnlyOurCulturesPatch
    {
        static bool Prefix(CharacterCreationManager characterCreationManager)
        {
            if (Game.Current == null) return false;

            foreach (CultureObject cultureObject in Game.Current.ObjectManager.GetObjectTypeList<CultureObject>())
            {
                if (CustomCultureDefinitions.Ids.Contains(cultureObject.StringId))
                {
                    characterCreationManager.CharacterCreationContent.AddCharacterCreationCulture(cultureObject, 1, 10);
                }
            }

            return false; // skip original method
        }
    }

    // Sort cultures by display name (fallbacks to shortened name then StringId)
    [HarmonyPatch(typeof(CharacterCreationCultureStageVM), "SortCultureList")]
    public static class SortCultureList_ByNameText_Prefix
    {
        static bool Prefix(MBBindingList<CharacterCreationCultureVM> listToWorkOn)
        {
            listToWorkOn.Sort(new NameTextComparer());
            return false;
        }

        private sealed class NameTextComparer : IComparer<CharacterCreationCultureVM>
        {
            public int Compare(CharacterCreationCultureVM x, CharacterCreationCultureVM y)
            {
                string sx = x?.NameText ?? x?.ShortenedNameText ?? x?.Culture?.StringId ?? string.Empty;
                string sy = y?.NameText ?? y?.ShortenedNameText ?? y?.Culture?.StringId ?? string.Empty;
                return StringComparer.InvariantCultureIgnoreCase.Compare(sx, sy);
            }
        }
    }
}
