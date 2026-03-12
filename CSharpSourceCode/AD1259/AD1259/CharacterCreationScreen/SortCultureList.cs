using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.CharacterCreation;
using TaleWorlds.Library;

namespace AD1259.Patches
{
    [HarmonyPatch(typeof(CharacterCreationCultureStageVM), "SortCultureList")]
    public static class SortCultureList_ByNameText_Prefix
    {
        private static bool Prefix(MBBindingList<CharacterCreationCultureVM> listToWorkOn)
        {
            try
            {
                listToWorkOn.Sort(new SortCultureList_ByNameText_Prefix.NameTextComparer());
            }
            catch (Exception)
            {
                // Errors are silently ignored (original behavior without logging)
            }
            return false;
        }
        private sealed class NameTextComparer : IComparer<CharacterCreationCultureVM>
        {
            public int Compare(CharacterCreationCultureVM x, CharacterCreationCultureVM y)
            {
                string text;
                if ((text = ((x != null) ? x.NameText : null)) == null && (text = ((x != null) ? x.ShortenedNameText : null)) == null)
                {
                    string text2;
                    if (x == null)
                    {
                        text2 = null;
                    }
                    else
                    {
                        CultureObject culture = x.Culture;
                        text2 = ((culture != null) ? culture.StringId : null);
                    }
                    text = (text2 ?? string.Empty);
                }
                string sx = text;
                string text3;
                if ((text3 = ((y != null) ? y.NameText : null)) == null && (text3 = ((y != null) ? y.ShortenedNameText : null)) == null)
                {
                    string text4;
                    if (y == null)
                    {
                        text4 = null;
                    }
                    else
                    {
                        CultureObject culture2 = y.Culture;
                        text4 = ((culture2 != null) ? culture2.StringId : null);
                    }
                    text3 = (text4 ?? string.Empty);
                }
                string sy = text3;
                return StringComparer.InvariantCultureIgnoreCase.Compare(sx, sy);
            }
        }
    }
}