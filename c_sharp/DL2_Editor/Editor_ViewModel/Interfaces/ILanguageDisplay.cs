namespace Editor_ViewModel.Interfaces
{
    using System;

    public interface ILanguageDisplay
    {
        string LanguageName { get; }

        string SkillLabel { get; }

        string ExperienceLabel { get; }

        string InventoryLabel { get; }

        string BackpackLabel { get; }

        string CampaignLabel { get; }

        string PlayerLabel { get; }

        string IdLabel { get; }

        string BaseSkillsLabel { get; }

        string LegendSkillsLabel { get; }

        string SkillPointsLabel { get; }

        string EnterNewValueLabel { get; }

        string NoFileSelected { get; }

        string InfoPageTitle { get; }

        string InfoPageIntroductionText { get; }

        string UnlockableItemsLabel { get; }

        string ItemsLabel { get; }

        string FileInformationLabel { get; }

        string FileInformationText { get; }

        string FileLabel { get; }

        string SizeLabel { get; }

        string ToBeContinuedLabel { get; }
    }
}
