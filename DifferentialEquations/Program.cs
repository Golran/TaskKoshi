using System;
using System.Windows.Forms;
using Autofac;

namespace DifferentialEquations
{
    internal static class Program
    {
        /// <summary>
        ///     Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var dependencyBuilder = new DependencyBuilder();
            var container = dependencyBuilder.CreateContainer();
            var form = container.Build().Resolve<MyForm>();
            Application.Run(form);
        }
    }
}