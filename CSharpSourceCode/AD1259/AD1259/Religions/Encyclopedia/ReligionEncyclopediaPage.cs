using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using AD1259.Religion.Models;
using HarmonyLib;
using TaleWorlds.CampaignSystem.Encyclopedia;
using TaleWorlds.Localization;

namespace AD1259.Religion.Encyclopedia
{
    /// <summary>
    /// Encyclopedia page that lists all religions in the AD 1259 world.
    /// Each list entry includes the full description, cultures, follower count,
    /// and the relationship matrix row for that religion.
    /// 
    /// Individual detail pages are not supported without custom Gauntlet UI templates.
    /// All information is shown directly in the list view instead.
    /// </summary>
    public class ReligionEncyclopediaPage : EncyclopediaPage
    {
        private ReligionEncyclopediaPage() : base() { }

        protected override IEnumerable<EncyclopediaListItem> InitializeListItems()
        {
            var items = new List<EncyclopediaListItem>();

            foreach (var kvp in ReligionManager.Religions)
            {
                ReligionObject religion = kvp.Value;
                int heroCount = ReligionManager.CountHeroesWithReligion(religion.StringId);
                List<string> cultures = ReligionManager.GetCulturesForReligion(religion.StringId);

                // Build a rich description for the list view
                StringBuilder sb = new StringBuilder();
                sb.Append(religion.Description.ToString());
                sb.Append(" | Followers: ");
                sb.Append(heroCount);
                sb.Append(" | Cultures: ");
                sb.Append(string.Join(", ", cultures));

                // Add relation matrix row
                Dictionary<string, int> relations = ReligionManager.GetRelationRow(religion.StringId);
                if (relations.Count > 0)
                {
                    sb.Append(" | Relations: ");
                    bool first = true;
                    foreach (var rel in relations)
                    {
                        if (rel.Key == religion.StringId)
                            continue; // skip self

                        if (ReligionManager.Religions.TryGetValue(rel.Key, out ReligionObject otherRel))
                        {
                            if (!first) sb.Append(", ");
                            string sign = rel.Value >= 0 ? "+" : "";
                            sb.Append(otherRel.ShortName);
                            sb.Append(" ");
                            sb.Append(sign);
                            sb.Append(rel.Value);
                            first = false;
                        }
                    }
                }

                items.Add(new EncyclopediaListItem(
                    religion,
                    religion.Name.ToString(),
                    sb.ToString(),
                    religion.StringId,
                    "Religion",
                    true
                ));
            }

            return items;
        }

        protected override IEnumerable<EncyclopediaFilterGroup> InitializeFilterItems()
        {
            return new List<EncyclopediaFilterGroup>();
        }

        protected override IEnumerable<EncyclopediaSortController> InitializeSortControllers()
        {
            return new List<EncyclopediaSortController>();
        }

        public override string GetViewFullyQualifiedName()
        {
            return "EncyclopediaReligionPage";
        }

        public override string GetStringID()
        {
            return "EncyclopediaReligion";
        }

        public override TextObject GetName()
        {
            return new TextObject("{=ad1259_rel_name}Religions");
        }

        public override TextObject GetDescriptionText()
        {
            return new TextObject("{=ad1259_rel_desc}The faiths and beliefs of the known world in AD 1259.");
        }

        public override bool IsValidEncyclopediaItem(object o)
        {
            return o is ReligionObject;
        }

        public static ReligionEncyclopediaPage CreateInstance()
        {
            var page = (ReligionEncyclopediaPage)FormatterServices.GetUninitializedObject(
                typeof(ReligionEncyclopediaPage));

            var identifierTypesField = AccessTools.Field(typeof(EncyclopediaPage), "_identifierTypes");
            identifierTypesField.SetValue(page, new Type[] { typeof(ReligionObject) });

            var identifiersField = AccessTools.Field(typeof(EncyclopediaPage), "_identifiers");
            var identifiers = new Dictionary<Type, string>();
            identifiers[typeof(ReligionObject)] = "Religion";
            identifiersField.SetValue(page, identifiers);

            var orderProp = AccessTools.Property(typeof(EncyclopediaPage), "HomePageOrderIndex");
            orderProp.SetValue(page, 550);

            var filtersField = AccessTools.Field(typeof(EncyclopediaPage), "_filters");
            filtersField.SetValue(page, page.InitializeFilterItems());

            var itemsField = AccessTools.Field(typeof(EncyclopediaPage), "_items");
            itemsField.SetValue(page, page.InitializeListItems());

            var sortField = AccessTools.Field(typeof(EncyclopediaPage), "_sortControllers");
            var sortControllers = new List<EncyclopediaSortController>
            {
                new EncyclopediaSortController(
                    new TextObject("{=koX9okuG}None"),
                    new ReligionNameComparer())
            };
            sortControllers.AddRange(page.InitializeSortControllers());
            sortField.SetValue(page, (IEnumerable<EncyclopediaSortController>)sortControllers);

            return page;
        }
    }

    public class ReligionNameComparer : EncyclopediaListItemComparerBase
    {
        public override int Compare(EncyclopediaListItem x, EncyclopediaListItem y)
        {
            return ResolveEquality(x, y);
        }

        public override string GetComparedValueText(EncyclopediaListItem item)
        {
            return "";
        }
    }
}
