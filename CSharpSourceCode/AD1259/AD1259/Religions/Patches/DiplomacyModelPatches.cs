using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Library;

namespace AD1259.Religion.Patches
{
    /// <summary>
    /// Patches DefaultDiplomacyModel.GetEffectiveRelation to add religion-based
    /// relationship modifiers. This is a Postfix patch — it runs after the original
    /// method and adjusts the returned value.
    ///
    /// This approach means religion modifiers appear naturally in the game's
    /// relationship system without brute-forcing relation changes via ChangeRelationAction.
    /// </summary>
    [HarmonyPatch(typeof(DefaultDiplomacyModel), "GetEffectiveRelation")]
    public static class GetEffectiveRelationPatch
    {
        [HarmonyPostfix]
        public static void Postfix(ref int __result, Hero hero1, Hero hero2)
        {
            if (hero1 == null || hero2 == null)
                return;

            int modifier = ReligionManager.GetRelationModifier(hero1, hero2);
            if (modifier != 0)
            {
                __result = MBMath.ClampInt(__result + modifier, -100, 100);
            }
        }
    }
}
