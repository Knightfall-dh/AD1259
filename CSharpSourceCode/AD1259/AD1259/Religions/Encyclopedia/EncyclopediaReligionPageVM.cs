using System.Text;
using AD1259.Religion.Models;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia.Pages;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace AD1259.Religion.Encyclopedia
{
    /// <summary>
    /// ViewModel for the religion detail encyclopedia page.
    /// Uses [EncyclopediaViewModel] so GetEncyclopediaPageInstance can discover it.
    /// Reuses the vanilla EncyclopediaConceptPage Gauntlet template which binds
    /// to TitleText, DescriptionText, and ExecuteLink.
    /// </summary>
    [EncyclopediaViewModel(typeof(ReligionObject))]
    public class EncyclopediaReligionPageVM : EncyclopediaContentPageVM
    {
        private ReligionObject _religion;
        private string _titleText;
        private string _descriptionText;
        private string _religionImageId;

        [DataSourceProperty]
        public string TitleText
        {
            get { return _titleText; }
            set
            {
                if (value != _titleText)
                {
                    _titleText = value;
                    OnPropertyChangedWithValue(value, "TitleText");
                }
            }
        }

        [DataSourceProperty]
        public string DescriptionText
        {
            get { return _descriptionText; }
            set
            {
                if (value != _descriptionText)
                {
                    _descriptionText = value;
                    OnPropertyChangedWithValue(value, "DescriptionText");
                }
            }
        }

        [DataSourceProperty]
        public string ReligionImageId
        {
            get { return _religionImageId; }
            set
            {
                if (value != _religionImageId)
                {
                    _religionImageId = value;
                    OnPropertyChangedWithValue(value, "ReligionImageId");
                }
            }
        }

        public EncyclopediaReligionPageVM(EncyclopediaPageArgs args)
            : base(args)
        {
            _religion = base.Obj as ReligionObject;
            if (_religion != null)
            {
                RefreshValues();
                Refresh();
            }
        }

        public override void RefreshValues()
        {
            base.RefreshValues();

            if (_religion == null)
                return;

            TitleText = _religion.Name.ToString();
            DescriptionText = _religion.Description.ToString();
            ReligionImageId = "religion_icon_" + _religion.StringId;
            UpdateBookmarkHintText();
        }

        public override void Refresh()
        {
            base.IsLoadingOver = false;
            base.IsLoadingOver = true;
        }

        public override string GetName()
        {
            return _religion?.Name?.ToString() ?? "";
        }

        public override string GetNavigationBarURL()
        {
            string home = HyperlinkTexts.GetGenericHyperlinkText("Home",
                GameTexts.FindText("str_encyclopedia_home").ToString());
            string listPage = HyperlinkTexts.GetGenericHyperlinkText("ListPage-Religion",
                "Religions");

            return home + " \\ " + listPage + " \\ " + GetName();
        }

        /// <summary>
        /// Called by the Gauntlet template when a hyperlink in the page is clicked.
        /// Routes the click back through the encyclopedia link system.
        /// </summary>
        public void ExecuteLink(string link)
        {
            Campaign.Current.EncyclopediaManager.GoToLink(link);
        }

        public override void ExecuteSwitchBookmarkedState()
        {
            // No bookmark support for custom objects
        }
    }
}
