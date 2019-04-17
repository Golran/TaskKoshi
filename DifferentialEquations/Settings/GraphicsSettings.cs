namespace DifferentialEquations.Settings
{
    public class GraphicsSettings
    {
        public bool ExactSolution { get; set; } = true;
        public bool ExplicitEulerMethod { get; set; } = true;
        public bool RungeKuttaMethod { get; set; } = false;
        public bool TrapeziumMethod { get; set; } = false;
    }
}