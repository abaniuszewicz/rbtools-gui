using Autofac;
using RBTools.Application.Config;

namespace RBTools.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<Configuration>().As<IConfiguration>().SingleInstance();
            builder.RegisterType<ConfigurationMemento>().As<IConfigurationMemento>();
            builder.RegisterType<PostCommandIssuer>().AsSelf().SingleInstance();
        }
    }
}
