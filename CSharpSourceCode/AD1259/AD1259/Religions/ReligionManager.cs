using System.Collections.Generic;
using System.IO;
using System.Xml;
using AD1259.Religion.Models;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;
using TaleWorlds.ModuleManager;

namespace AD1259.Religion
{
    public static class ReligionManager
    {
        private static readonly Dictionary<string, ReligionObject> _religionsById = new Dictionary<string, ReligionObject>();
        private static readonly Dictionary<string, string> _cultureToReligionId = new Dictionary<string, string>();

        // Relationship matrix: _relationMatrix["catholic"]["sunni"] = -40
        private static readonly Dictionary<string, Dictionary<string, int>> _relationMatrix
            = new Dictionary<string, Dictionary<string, int>>();

        public static IReadOnlyDictionary<string, ReligionObject> Religions => _religionsById;

        public static void LoadReligions()
        {
            _religionsById.Clear();
            _cultureToReligionId.Clear();
            _relationMatrix.Clear();

            string modulePath = ModuleHelper.GetModuleFullPath("AD1259");
            string xmlPath = Path.Combine(modulePath, "ModuleData", "religions.xml");

            if (!File.Exists(xmlPath))
            {
                InformationManager.DisplayMessage(new InformationMessage(
                    "AD1259 Religion: religions.xml not found at " + xmlPath,
                    Colors.Red));
                return;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);

            // Load religion definitions
            XmlNodeList religionNodes = doc.SelectNodes("Religions/Religion");
            if (religionNodes != null)
            {
                foreach (XmlNode node in religionNodes)
                {
                    string id = node.Attributes["id"]?.Value;
                    string name = node.Attributes["name"]?.Value ?? id;
                    string shortName = node.Attributes["short_name"]?.Value ?? name;
                    string description = node.Attributes["description"]?.Value ?? "";
                    string color = node.Attributes["color"]?.Value ?? "#FFFFFF";

                    if (!string.IsNullOrEmpty(id))
                    {
                        _religionsById[id] = new ReligionObject(id, name, shortName, description, color);
                    }
                }
            }

            // Load relationship matrix
            XmlNodeList matrixNodes = doc.SelectNodes("Religions/RelationMatrix/Relation");
            if (matrixNodes != null)
            {
                foreach (XmlNode node in matrixNodes)
                {
                    string from = node.Attributes["from"]?.Value;
                    string to = node.Attributes["to"]?.Value;
                    string valueStr = node.Attributes["value"]?.Value;

                    if (!string.IsNullOrEmpty(from) && !string.IsNullOrEmpty(to) && !string.IsNullOrEmpty(valueStr))
                    {
                        int value = int.Parse(valueStr);

                        if (!_relationMatrix.ContainsKey(from))
                            _relationMatrix[from] = new Dictionary<string, int>();

                        _relationMatrix[from][to] = value;
                    }
                }
            }

            // Load culture to religion mappings
            XmlNodeList mappingNodes = doc.SelectNodes("Religions/CultureMappings/Mapping");
            if (mappingNodes != null)
            {
                foreach (XmlNode node in mappingNodes)
                {
                    string culture = node.Attributes["culture"]?.Value;
                    string religion = node.Attributes["religion"]?.Value;

                    if (!string.IsNullOrEmpty(culture) && !string.IsNullOrEmpty(religion))
                    {
                        _cultureToReligionId[culture] = religion;
                    }
                }
            }

            InformationManager.DisplayMessage(new InformationMessage(
                $"AD1259 Religion: Loaded {_religionsById.Count} religions, {_relationMatrix.Count} matrix rows, {_cultureToReligionId.Count} culture mappings.",
                Colors.Green));
        }

        public static ReligionObject GetHeroReligion(Hero hero)
        {
            if (hero?.Culture == null)
                return null;

            return GetReligionForCulture(hero.Culture.StringId);
        }

        public static ReligionObject GetReligionForCulture(string cultureId)
        {
            if (string.IsNullOrEmpty(cultureId))
                return null;

            if (_cultureToReligionId.TryGetValue(cultureId, out string religionId))
            {
                if (_religionsById.TryGetValue(religionId, out ReligionObject religion))
                {
                    return religion;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the relationship modifier between two heroes using the matrix.
        /// Looks up _relationMatrix[hero1's religion][hero2's religion].
        /// Returns 0 if either hero has no religion or no matrix entry exists.
        /// </summary>
        public static int GetRelationModifier(Hero hero1, Hero hero2)
        {
            ReligionObject religion1 = GetHeroReligion(hero1);
            ReligionObject religion2 = GetHeroReligion(hero2);

            if (religion1 == null || religion2 == null)
                return 0;

            return GetRelationBetween(religion1.StringId, religion2.StringId);
        }

        /// <summary>
        /// Gets the relationship modifier between two religions by their string IDs.
        /// </summary>
        public static int GetRelationBetween(string religionId1, string religionId2)
        {
            if (_relationMatrix.TryGetValue(religionId1, out var row))
            {
                if (row.TryGetValue(religionId2, out int value))
                {
                    return value;
                }
            }

            return 0;
        }

        public static List<string> GetCulturesForReligion(string religionId)
        {
            List<string> cultures = new List<string>();
            foreach (var kvp in _cultureToReligionId)
            {
                if (kvp.Value == religionId)
                    cultures.Add(kvp.Key);
            }
            return cultures;
        }

        public static int CountHeroesWithReligion(string religionId)
        {
            int count = 0;
            if (Campaign.Current == null)
                return 0;

            foreach (Hero hero in Hero.AllAliveHeroes)
            {
                ReligionObject rel = GetHeroReligion(hero);
                if (rel != null && rel.StringId == religionId)
                    count++;
            }
            return count;
        }

        /// <summary>
        /// Returns the full relation row for a given religion (how it views all others).
        /// Used by the encyclopedia detail page.
        /// </summary>
        public static Dictionary<string, int> GetRelationRow(string religionId)
        {
            if (_relationMatrix.TryGetValue(religionId, out var row))
                return new Dictionary<string, int>(row);

            return new Dictionary<string, int>();
        }
    }
}
