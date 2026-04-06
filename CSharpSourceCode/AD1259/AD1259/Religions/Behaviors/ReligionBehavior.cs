using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace AD1259.Religion.Behaviors
{
    /// <summary>
    /// Campaign behavior for the religion system.
    /// Currently handles:
    ///   - Displaying player religion on new game / load
    ///   - Future: conversion events, religious wars, holy orders, etc.
    /// </summary>
    public class ReligionBehavior : CampaignBehaviorBase
    {
        private bool _hasShownPlayerReligion = false;

        public override void RegisterEvents()
        {
            CampaignEvents.OnNewGameCreatedEvent.AddNonSerializedListener(this, OnNewGameCreated);
            CampaignEvents.OnGameLoadedEvent.AddNonSerializedListener(this, OnGameLoaded);
        }

        public override void SyncData(IDataStore dataStore)
        {
            // Religion is derived from culture, so no save data needed for v1.
            // Future versions could save individual hero religion overrides here
            // (e.g. if you allow conversion).
        }

        private void OnNewGameCreated(CampaignGameStarter starter)
        {
            ShowPlayerReligion();
        }

        private void OnGameLoaded(CampaignGameStarter starter)
        {
            ShowPlayerReligion();
        }

        private void ShowPlayerReligion()
        {
            if (_hasShownPlayerReligion)
                return;

            if (Hero.MainHero == null)
                return;

            _hasShownPlayerReligion = true;

            var playerReligion = ReligionManager.GetHeroReligion(Hero.MainHero);
            if (playerReligion != null)
            {
                InformationManager.DisplayMessage(new InformationMessage(
                    $"Your character follows {playerReligion.Name}.",
                    Colors.Cyan));
            }
            else
            {
                InformationManager.DisplayMessage(new InformationMessage(
                    "Your character has no religion.",
                    Colors.Gray));
            }
        }
    }
}
