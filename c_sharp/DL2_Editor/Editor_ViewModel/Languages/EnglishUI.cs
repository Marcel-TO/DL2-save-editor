namespace Editor_ViewModel.Languages
{
    using Editor_ViewModel.Interfaces;

    public class EnglishUI : ILanguageDisplay
    {
        public string LanguageName => "English";

        public string SkillLabel => "Skill";

        public string ExperienceLabel => "Experience";

        public string InventoryLabel => "Inventory";

        public string BackpackLabel => "Backpack";

        public string CampaignLabel => "Campaign";

        public string PlayerLabel => "Player";

        public string BaseSkillsLabel => "Base Skills";

        public string LegendSkillsLabel => "Legend Skills";

        public string SkillPointsLabel => "Skill Points";

        public string EnterNewValueLabel => "Enter new value";

        public string NoFileSelected => "Please select a File to see the full hex code. Keep in Mind though, that loading the file could take a while.";
    }
}
