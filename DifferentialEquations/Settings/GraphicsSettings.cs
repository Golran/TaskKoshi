using System.ComponentModel;

namespace DifferentialEquations.Settings
{
    public class GraphicsSettings
    {
        //UsingMethod0
        [DisplayName("Точное решение")]
        [Category("Отображать графики")]
        public bool ExactSolution { get; set; } = true;

        //UsingMethod1
        [DisplayName("Метод Эйлера")]
        [Category("Отображать графики")]
        public bool ExplicitEulerMethod { get; set; } = true;

        //UsingMethod2
        [DisplayName("Метод Рунге-Кутта 4 порядка")]
        [Category("Отображать графики")]
        public bool RungeKuttaMethod { get; set; } = true;

        //UsingMethod3
        [DisplayName("Метод трапеций")]
        [Category("Отображать графики")]
        public bool TrapeziumMethod { get; set; } = true;

        //UsingMethod0
        [DisplayName("Точное решение")]
        [Category("Толщина графика")]
        public int ExactSolutionBorderWidth { get; set; } = 5;

        //UsingMethod1
        [DisplayName("Метод Эйлера")]
        [Category("Толщина графика")]
        public int ExplicitEulerMethodBorderWidth { get; set; } = 5;

        //UsingMethod2
        [DisplayName("Метод Рунге-Кутта 4 порядка")]
        [Category("Толщина графика")]
        public int RungeKuttaMethodBorderWidth { get; set; } = 5;

        //UsingMethod3
        [DisplayName("Метод трапеций")]
        [Category("Толщина графика")]
        public int TrapeziumMethodBorderWidth { get; set; } = 5;


    }
}