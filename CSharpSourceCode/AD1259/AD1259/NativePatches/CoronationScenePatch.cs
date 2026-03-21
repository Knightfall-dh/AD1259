using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SceneInformationPopupTypes;
using TaleWorlds.Core;

namespace AD1259.Patches
{
    [HarmonyPatch(typeof(CampaignSceneNotificationHelper), nameof(CampaignSceneNotificationHelper.GetBodyguardOfCulture))]
    internal class GetBodyGuardOfCulturePatch
    {
        [HarmonyPostfix]
        static void Postfix(ref SceneNotificationData.SceneNotificationCharacter __result, CultureObject culture)
        {
            string text = string.Concat(new object[] { "cutscene_bodyguard_", culture.StringId });
            CharacterObject character = Game.Current.ObjectManager.GetObject<CharacterObject>(text) ?? Game.Current.ObjectManager.GetObject<CharacterObject>("fighter_sturgia");
            BodyProperties bodyProperties = character.GetBodyProperties(character.Equipment, MBRandom.RandomInt(100));
            Equipment equipment = character.RandomBattleEquipment;
            __result = new SceneNotificationData.SceneNotificationCharacter(character, equipment, bodyProperties, false, uint.MaxValue, uint.MaxValue, false);
        }
    }
}