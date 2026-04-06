using System;
using System.Collections.Generic;
using AD1259.Religion.Encyclopedia;
using AD1259.Religion.Models;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Encyclopedia;
using TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia;
using TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia.Pages;
using TaleWorlds.Core.ViewModelCollection.Generic;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace AD1259.Religion.Patches
{
    /// <summary>
    /// Injects our ReligionEncyclopediaPage into the encyclopedia system after
    /// all vanilla pages have been created.
    /// </summary>
    [HarmonyPatch(typeof(EncyclopediaManager), "CreateEncyclopediaPages")]
    public static class CreateEncyclopediaPagesPatch
    {
        [HarmonyPostfix]
        public static void Postfix(EncyclopediaManager __instance)
        {
            try
            {
                var pagesField = AccessTools.Field(typeof(EncyclopediaManager), "_pages");
                var pages = (Dictionary<Type, EncyclopediaPage>)pagesField.GetValue(__instance);

                if (pages == null)
                {
                    InformationManager.DisplayMessage(new InformationMessage(
                        "AD1259 Religion: Failed to access encyclopedia pages dictionary.",
                        Colors.Red));
                    return;
                }

                var religionPage = ReligionEncyclopediaPage.CreateInstance();
                pages[typeof(ReligionObject)] = religionPage;

                InformationManager.DisplayMessage(new InformationMessage(
                    "AD1259 Religion: Encyclopedia page registered.",
                    Colors.Green));
            }
            catch (Exception ex)
            {
                InformationManager.DisplayMessage(new InformationMessage(
                    "AD1259 Religion: Error registering encyclopedia page - " + ex.Message,
                    Colors.Red));
            }
        }
    }

    /// <summary>
    /// Intercepts encyclopedia link clicks for Religion items.
    /// Since ReligionObject isn't an MBObjectBase, the vanilla GoToLink
    /// can't resolve it via MBObjectManager. We bypass that and directly
    /// invoke _executeLink with our ReligionObject, which feeds into
    /// SetEncyclopediaPage → GetEncyclopediaPageInstance → our VM.
    /// </summary>
    [HarmonyPatch(typeof(EncyclopediaManager), "GoToLink", new Type[] { typeof(string), typeof(string) })]
    public static class GoToLinkReligionPatch
    {
        [HarmonyPrefix]
        public static bool Prefix(EncyclopediaManager __instance, string pageType, string stringID)
        {
            if (pageType != "Religion")
                return true;

            if (!ReligionManager.Religions.TryGetValue(stringID, out ReligionObject religion))
                return true;

            // Get the private _executeLink action and invoke it directly,
            // bypassing the MBObjectBase resolution that would fail for ReligionObject
            var executeLinkField = AccessTools.Field(typeof(EncyclopediaManager), "_executeLink");
            var executeLink = executeLinkField.GetValue(__instance) as Action<string, object>;

            if (executeLink != null)
            {
                executeLink(pageType, religion);
            }

            return false;
        }
    }

    /// <summary>
    /// Patches ExecuteBarLink in the navigator bar to handle Religion breadcrumb clicks.
    /// The vanilla method has a hardcoded switch that only handles vanilla page types.
    /// </summary>
    [HarmonyPatch(typeof(EncyclopediaNavigatorVM), "ExecuteBarLink")]
    public static class ExecuteBarLinkPatch
    {
        [HarmonyPrefix]
        public static bool Prefix(string targetID)
        {
            if (targetID.Contains("ListPage"))
            {
                string[] parts = targetID.Split(new char[] { '-' });
                if (parts.Length > 1 && parts[1] == "Religion")
                {
                    Campaign.Current.EncyclopediaManager.GoToLink("ListPage", "Religion");
                    return false; // skip vanilla switch
                }
            }
            return true;
        }
    }

    /// <summary>
    /// Adds Religion and Religious Relation entries to the hero encyclopedia
    /// Info/Stats panel. NOT auto-patched by PatchAll() — applied manually
    /// after the campaign has loaded to avoid corrupting the VM vtable during
    /// character creation.
    /// </summary>
    public static class HeroPageReligionPatch
    {
        public static void Postfix(EncyclopediaHeroPageVM __instance)
        {
            try
            {
                if (Campaign.Current == null)
                    return;

                if (__instance.Stats == null)
                    return;

                Hero hero = (Hero)AccessTools.Field(typeof(EncyclopediaHeroPageVM), "_hero")
                    .GetValue(__instance);
                if (hero == null || hero.Culture == null)
                    return;

                ReligionObject religion = ReligionManager.GetHeroReligion(hero);
                if (religion == null)
                    return;

                __instance.Stats.Add(new StringPairItemVM("Religion:", religion.Name.ToString()));

                if (Hero.MainHero != null && hero != Hero.MainHero)
                {
                    int modifier = ReligionManager.GetRelationModifier(Hero.MainHero, hero);
                    string modifierText = modifier >= 0 ? "+" + modifier.ToString() : modifier.ToString();
                    __instance.Stats.Add(new StringPairItemVM("Religious Relation:", modifierText));
                }
            }
            catch (Exception)
            {
                // Silently fail
            }
        }
    }
}
