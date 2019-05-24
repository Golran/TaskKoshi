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
            var yi = 0.1;
            result[0] = new Node(0, yi);
            for (var i = 1; i < numberPoints + 1; i++)
            {
                var xi = (i - 1) * h;
                var k1 = h * f(xi, yi);
                var k2 = h * f(xi + h / 2, yi + k1 / 2);
                var k3 = h * f(xi + h / 2, yi + k2 / 2);
                var k4 = h * f(xi + h, yi + k2);
                yi = yi + (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                result[i] = new Node(i * h, yi);
            }

            return result;
        }

        //Method3
        public static Node[] TrapeziumMethod(int numberPoints)
        {
            var h = 1.0 / numberPoints;
            var result = new Node[numberPoints + 1];
            Func<double, double, double> f = (x, y) => 50 * y * (x - 0.6) * (x - 0.85);
            var yi = 0.1;
            result[0] = new Node(0, yi);
            for (var i = 1; i < numberPoints + 1; i++)
            {
                var xi = (i - 1) * h;
                Func<double, double> fmpi = y => yi + h / 2 * (f(xi, yi) + f(xi + h, y));
                var yi1 = MPI(fmpi, 0.5E-10);
                yi = yi + h / 2 * (f(xi, yi) + f(xi + h, yi1));
                result[i] = new Node(i * h, yi);
            }

            return result;
        }

        private static double MPI(Func<double, double> fmpi, double eps)
        {
            var x = 1.0;
            var x1 = fmpi(x);
            while (Math.Abs(x1 - x) > eps)
            {
                x = x1;
                x1 = fmpi(x);
            }

            return x1;
        }
    }
}