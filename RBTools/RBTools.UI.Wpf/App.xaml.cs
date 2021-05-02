using System.Windows;
using Autofac;
using RBTools.Application;
using RBTools.Infrastructure.Persistence;
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
            builder.RegisterModule<WpfModule>();

            var container = builder.Build();
            using var scope = container.BeginLifetimeScope();
            var mainWindow = scope.Resolve<MainWindow>();
            mainWindow.ShowDialog();
        }
    }
}
