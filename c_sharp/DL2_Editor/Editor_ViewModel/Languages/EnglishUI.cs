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

        public string IdLabel => "IDs";

        public string BaseSkillsLabel => "Base Skills";

        public string LegendSkillsLabel => "Legend Skills";

        public string SkillPointsLabel => "Skill Points";

        public string EnterNewValueLabel => "Enter new value";

        public string NoFileSelected => "Please select a File to see the full hex code. Keep in Mind though, that loading the file could take a while.";

        public string InfoPageTitle => "Hello there fellow Pilgrim!";

        public string InfoPageIntroductionText 
        {
            get
            {
                return "Introducing our work-in-progress application, the first public Dying Light 2 Editor! Developed by a dedicated team of two passionate gamers, our editor empowers you to take control of your Dying Light 2 experience like never before. With this tool, you can manipulate stats and customize items to tailor your in-game adventure to your liking. While not all features are implemented just yet, we're committed to continuously improving and expanding our editor to enhance your gaming journey. Stay tuned for updates and join us in shaping your Dying Light 2 experience!";
            }
        }

        public string UnlockableItemsLabel => "Unlockable Items";

        public string ItemsLabel => "Items";

        public string FileInformationLabel => "File information";

        public string FileInformationText => "The following file is selected:";

        public string FileLabel => "File";

        public string SizeLabel => "Size";

        public string ToBeContinuedLabel => "To be continued.....";

        public string ChangeLabel => "Change";
    }
}
