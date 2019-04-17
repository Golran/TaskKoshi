using System.Drawing;

namespace DifferentialEquations.Settings
{
    public class PaletteSettings
    {
        public Color ExactSolution { get; set; } = Color.Blue;
        public Color ExplicitEulerMethod { get; set; } = Color.DarkOrchid;
        public Color RungeKuttaMethod { get; set; } = Color.Red;
        public Color TrapeziumMethod { get; set; } = Color.Green;
    }
}