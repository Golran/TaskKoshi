using System.ComponentModel;

namespace DifferentialEquations.Settings
{
    public class NumberPointsSettings
    {
        [DisplayName("Колличество точек")]
        [Category("Точки")]
        public int NumberPoints { get; set; } = 18;
    }
}