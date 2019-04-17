using Autofac;
using DifferentialEquations.Actions;
using DifferentialEquations.Settings;

namespace DifferentialEquations
{
    public class DependencyBuilder
    {
        public ContainerBuilder CreateContainer()
        {
            var container = new ContainerBuilder();

            container.RegisterType<PaletteSettings>().AsSelf().SingleInstance();
            container.RegisterType<GraphicsSettings>().AsSelf().SingleInstance();
            container.RegisterType<NumberPointsSettings>().AsSelf().SingleInstance();

            container.RegisterType<PaletteSettingsAction>().As<IUiAction>();
            container.RegisterType<CreateAction>().As<IUiAction>();
            container.RegisterType<NumberPointsSettingsAction>().As<IUiAction>();
            container.RegisterType<GraphicsSettingsAction>().As<IUiAction>();
            container.RegisterType<ChartHolder>().AsSelf().SingleInstance();
            container.RegisterType<MyForm>().AsSelf();
            return container;
        }
    }
}