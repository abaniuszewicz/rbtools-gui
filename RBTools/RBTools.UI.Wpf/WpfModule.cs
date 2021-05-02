using Autofac;
using RBTools.UI.Wpf.ViewModels;
using RBTools.UI.Wpf.Views;

namespace RBTools.UI.Wpf
{
    public class WpfModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<CommunicationViewModel>().AsSelf();
            builder.RegisterType<SendViewModel>().AsSelf();
            builder.RegisterType<SettingsViewModel>().AsSelf();
            builder.RegisterType<ConfigurationViewModel>().AsSelf()
                .SingleInstance();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<CommunicationView>().AsSelf();
            builder.RegisterType<SendView>().AsSelf();
            builder.RegisterType<SettingsView>().AsSelf();
        }
    }
}
