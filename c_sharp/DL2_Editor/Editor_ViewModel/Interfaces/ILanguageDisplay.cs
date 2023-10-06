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

        string BaseSkillsLabel { get; }

        string LegendSkillsLabel { get; }

        string SkillPointsLabel { get; }

        string EnterNewValueLabel { get; }

        string NoFileSelected { get; }
    }
}
