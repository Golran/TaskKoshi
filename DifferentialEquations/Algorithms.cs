using System;

namespace DifferentialEquations
{
    public static class Algorithms
    {
        //Method0
        public static Node[] ExactSolution(int numberPoints)
        {
            var h = 1.0 / numberPoints;
            var result = new Node[numberPoints + 1];
            Func<double, double> solution = x =>
                0.1 * Math.Pow(Math.E, 50 / 3.0 * x * x * x - 36.25 * x * x + 25.5 * x);
            for (var i = 0; i < numberPoints + 1; i++) result[i] = new Node(i * h, solution(i * h));

            return result;
        }
        //Method1
        public static Node[] ExplicitEulerMethod(int numberPoints)
        {
            var h = 1.0 / numberPoints;
            var result = new Node[numberPoints + 1];
            Func<double, double, double> f = (x, y) => 50 * y * (x - 0.6) * (x - 0.85);
            var yn = 0.1;
            result[0] = new Node(0, yn);
            for (var i = 1; i < numberPoints + 1; i++)
            {
                yn = yn + h * f(h * (i - 1), yn);
                result[i] = new Node(i * h, yn);
            }

            return result;
        }
        //Method2
        public static Node[] RungeKuttaMethod(int numberPoints)
        {
            var h = 1.0 / numberPoints;
            var result = new Node[numberPoints + 1];
            Func<double, double, double> f = (x, y) => 50 * y * (x - 0.6) * (x - 0.85);
            for (var i = 0; i < numberPoints + 1; i++) result[i] = new Node(i * h, i * i * h * h);
            return result;
        }
        //Method3
        public static Node[] TrapeziumMethod(int numberPoints)
        {
            var h = 1.0 / numberPoints;
            var result = new Node[numberPoints + 1];
            Func<double, double, double> f = (x, y) => 50 * y * (x - 0.6) * (x - 0.85);
            for (var i = 0; i < numberPoints + 1; i++) result[i] = new Node(i * h, Math.Pow(Math.E,i*h));
            return result;
        }
    }
}