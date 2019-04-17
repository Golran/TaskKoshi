﻿using DifferentialEquations.Settings;

namespace DifferentialEquations.Actions
{
    public class GraphicsSettingsAction : IUiAction
    {
        private readonly GraphicsSettings graphicsSettings;

        public GraphicsSettingsAction(GraphicsSettings graphicsSettings)
        {
            this.graphicsSettings = graphicsSettings;
        }

        public string Name => "Графики";
        public string Category => "Настройки";

        public void Perform()
        {
            SettingsForm.For(graphicsSettings).ShowDialog();
        }
    }
}