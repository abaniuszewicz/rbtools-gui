using Autofac;
using RBTools.Application.Configuration;

namespace RBTools.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<Settings>().As<ISettings>().SingleInstance();
            builder.RegisterType<SettingsMemento>().As<ISettingsMemento>();
            builder.RegisterType<PostCommandIssuer>().AsSelf().SingleInstance();
        }
    }
}
