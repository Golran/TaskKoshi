using System.Drawing;

namespace DifferentialEquations.Settings
{
    public class PaletteSettings
    {
        //ColorGraphicsMethod0
        public Color ExactSolution { get; set; } = Color.Blue;
        //ColorGraphicsMethod1
        public Color ExplicitEulerMethod { get; set; } = Color.DarkOrchid;
        //ColorGraphicsMethod2
        public Color RungeKuttaMethod { get; set; } = Color.Red;
        //ColorGraphicsMethod3
        public Color TrapeziumMethod { get; set; } = Color.Green;
    }
}