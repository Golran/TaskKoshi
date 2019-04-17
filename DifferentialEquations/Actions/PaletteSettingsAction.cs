using DifferentialEquations.Settings;

namespace DifferentialEquations.Actions
{
    public class PaletteSettingsAction : IUiAction
    {
        private readonly PaletteSettings paletteSettings;

        public PaletteSettingsAction(PaletteSettings paletteSettings)
        {
            this.paletteSettings = paletteSettings;
        }

        public string Name => "Цвета графиков";
        public string Category => "Настройки";

        public void Perform()
        {
            SettingsForm.For(paletteSettings).ShowDialog();
        }
    }
}