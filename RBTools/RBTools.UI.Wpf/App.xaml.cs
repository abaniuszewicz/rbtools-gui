using System.Windows;
using Autofac;
using RBTools.Application;
using RBTools.Infrastructure.Persistence;
using RBTools.UI.Wpf.ViewModels;
using RBTools.UI.Wpf.Views;

namespace RBTools.UI.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<PersistenceModule>();

            builder.RegisterType<CommunicationViewModel>().AsSelf();
            builder.RegisterType<SendViewModel>().AsSelf();
            builder.RegisterType<SettingsViewModel>().AsSelf();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<CommunicationView>().AsSelf();
            builder.RegisterType<SendView>().AsSelf();
            builder.RegisterType<SettingsView>().AsSelf();

            var container = builder.Build();
            using var scope = container.BeginLifetimeScope();
            var mainWindow = scope.Resolve<MainWindow>();
            mainWindow.ShowDialog();
        }
    }
}
