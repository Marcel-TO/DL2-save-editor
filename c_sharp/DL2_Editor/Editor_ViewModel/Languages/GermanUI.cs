namespace Editor_ViewModel.Languages
{
    using Editor_ViewModel.Interfaces;

    public class GermanUI : ILanguageDisplay
    {
        public string LanguageName => "Deutsch";

        public string SkillLabel => "Skill";

        public string ExperienceLabel => "Erfahrung";

        public string InventoryLabel => "Inventar";

        public string BackpackLabel => "Rucksack";

        public string CampaignLabel => "Kampagne";

        public string PlayerLabel => "Spieler";

        public string BaseSkillsLabel => "Basis Skills";

        public string LegendSkillsLabel => "Legenden Skills";

        public string SkillPointsLabel => "Skill Punkte";

        public string EnterNewValueLabel => "Gib einen neuen Wert ein";

        public string NoFileSelected => "Bitte wählen Sie eine Datei aus, um den vollständigen Hex-Code zu sehen. Beachten Sie jedoch, dass das Laden der Datei eine Weile dauern kann.";

        public string InfoPageTitle => "Hallo, Pilgerfreund!";

        public string InfoPageIntroductionText 
        {
            get
            {
                return "Fortsetzung folgt......";
            }
        }

        public string UnlockableItemsLabel => "Freischaltbarer Gegenstand";

        public string ItemsLabel => "Gegenstände";

        public string FileInformationLabel => "Datei Information";

        public string FileInformationText => "Die angegebene Datei wurde ausgewählt:";

        public string FileLabel => "Datei";

        public string SizeLabel => "Größe";
    }
}
