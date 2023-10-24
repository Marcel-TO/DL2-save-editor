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

        public string IdLabel => "IDs";

        public string BaseSkillsLabel => "Habilidades básicas";

        public string LegendSkillsLabel => "Habilidades de leyenda";

        public string SkillPointsLabel => "Puntos de habilidad";

        public string EnterNewValueLabel => "Introducir nuevo valor";

        public string NoFileSelected => "Seleccione un archivo para ver el código hexadecimal completo. Tenga en cuenta, sin embargo, que la carga del archivo puede tardar un poco.";
    
        public string InfoPageTitle => "Hola, amigo peregrino!";

        public string InfoPageIntroductionText 
        {
            get
            {
                return "Continuará en ....";
            }
        }

        public string UnlockableItemsLabel => "Objeto desbloqueable";

        public string ItemsLabel => "Artículos";

        public string FileInformationLabel => "información de archivo";

        public string FileInformationText => "Se selecciona el siguiente archivo:";

        public string FileLabel => "Archivo";

        public string SizeLabel => "Talla";

        public string ToBeContinuedLabel => "Continuación......";

        public string ChangeLabel => "Cambiar";
    }
}
