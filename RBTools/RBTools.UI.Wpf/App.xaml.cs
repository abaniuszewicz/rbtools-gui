using Autofac;
using System.Windows;
using RBTools.Application;
using RBTools.Infrastructure.Persistence.IO;
using RBTools.Infrastructure.Persistence.Serialization;
using RBTools.UI.Wpf.Models;
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
            IFileLoader loader = new JsonFileLoader();
            ISerializer serializer = new JsonSerializer();
            var settings = GetSettings(loader, serializer);
            
            var builder = new ContainerBuilder();
            
            builder.RegisterInstance(loader).As<IFileLoader>();
            builder.RegisterInstance(serializer).As<ISerializer>();
            builder.RegisterType<JsonFileSaver>().As<IFileSaver>();
            
            builder.RegisterInstance(settings).AsSelf()
                .SingleInstance();
            builder.RegisterType<PostCommandIssuer>().AsSelf()
                .WithParameter("root", settings?.RepositoryRoot)
                .SingleInstance();

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
        
        private static Settings GetSettings(IFileLoader loader, ISerializer serializer)
        {
            try
            {
                var content = loader.Load("settings");
                return serializer.Deserialize<Settings>(content);
            }
            catch
            {
                return new Settings(); // we expect that settings might not exist yet upon first run
            }
        }
    }
}