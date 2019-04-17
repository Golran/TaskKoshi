using DifferentialEquations.Settings;

namespace DifferentialEquations.Actions
{
    public class NumberPointsSettingsAction : IUiAction
    {
        private readonly NumberPointsSettings numberPointsSettings;

        public NumberPointsSettingsAction(NumberPointsSettings numberPointsSettings)
        {
            this.numberPointsSettings = numberPointsSettings;
        }

        public string Name => "Количество точек";
        public string Category => "Настройки";

        public void Perform()
        {
            SettingsForm.For(numberPointsSettings).ShowDialog();
        }
    }
}