namespace Editor_ViewModel.Languages
{
    using Editor_ViewModel.Interfaces;

    public class SpanishUI : ILanguageDisplay
    {
        public string LanguageName => "Español";

        public string SkillLabel => "Habilidad";

        public string ExperienceLabel => "Experiencia";

        public string InventoryLabel => "Inventario";

        public string BackpackLabel => "Mochila";

        public string CampaignLabel => "Campaña";

        public string PlayerLabel => "Jugador";

        public string BaseSkillsLabel => "Habilidades básicas";

        public string LegendSkillsLabel => "Habilidades de leyenda";

        public string SkillPointsLabel => "Puntos de habilidad";

        public string EnterNewValueLabel => "Introducir nuevo valor";

        public string NoFileSelected => "Seleccione un archivo para ver el código hexadecimal completo. Tenga en cuenta, sin embargo, que la carga del archivo puede tardar un poco.";
    
        public string InfoPageTitle => "Hola, amigo peregrino!"

        public string InfoPageIntroductionText 
        {
            get
            {
                return "To be continued...."
            }
        }
    }
}
