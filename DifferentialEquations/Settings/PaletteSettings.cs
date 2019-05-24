using System.ComponentModel;
using System.Drawing;

namespace DifferentialEquations.Settings
{
    public class PaletteSettings
    {
        //ColorGraphicsMethod0
        [DisplayName("Точное решение")]
        [Category("Цвет графика")]
        public Color ExactSolution { get; set; } = Color.Blue;

        //ColorGraphicsMethod1
        [DisplayName("Метод Эйлера")]
        [Category("Цвет графика")]
        public Color ExplicitEulerMethod { get; set; } = Color.DarkOrchid;

        //ColorGraphicsMethod2
        [DisplayName("Метод Рунге-Кутта 4 порядка")]
        [Category("Цвет графика")]
        public Color RungeKuttaMethod { get; set; } = Color.Red;

        //ColorGraphicsMethod3
        [DisplayName("Метод трапеций")]
        [Category("Цвет графика")]
        public Color TrapeziumMethod { get; set; } = Color.Green;
    }
}