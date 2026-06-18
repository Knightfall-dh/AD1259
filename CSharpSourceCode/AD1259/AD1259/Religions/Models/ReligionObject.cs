using TaleWorlds.Localization;

namespace AD1259.Religion.Models
{
    /// <summary>
    /// Represents a religion in the AD 1259 mod.
    /// Plain data class — not an MBObjectBase since religions are static data
    /// loaded once and never serialized by the save system.
    /// </summary>
    public class ReligionObject
    {
        public string StringId { get; }
        public TextObject Name { get; }
        public TextObject ShortName { get; }
        public TextObject Description { get; }
        public string ColorHex { get; }

        public ReligionObject(string stringId, string name, string shortName, string description, string colorHex)
        {
            StringId = stringId;
            Name = new TextObject(name);
            ShortName = new TextObject(shortName);
            Description = new TextObject(description);
            ColorHex = colorHex;
        }

        public override string ToString()
        {
            return ShortName.ToString();
        }
    }
}
