using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ModernWpf.Controls;
using RBToolsContextMenu.Application;
using RBToolsContextMenu.Persistence.IO;
using RBToolsContextMenu.Persistence.Serialization;
using RBToolsContextMenu.UI.Wpf.Utilities.Settings;
using RBToolsContextMenu.UI.Wpf.ViewModels;
using WindowsControls = System.Windows.Controls;

namespace RBToolsContextMenu.UI.Wpf.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IDisposable
    {
        private readonly PostCommandIssuer _postCommandIssuer;
        private readonly IEnumerable<(NavigationViewItemBase NavigationItem, WindowsControls.Page destination)> _navigationItemToDestinationType;

        public MainWindow()
        {
            InitializeComponent();

            IFileLoader loader = new JsonFileLoader();
            IFileSaver saver = new JsonFileSaver();
            ISerializer serializer = new JsonSerializer();

            var settingsViewModel = new SettingsViewModel(loader, saver, serializer);
            var sendViewModel = new SendViewModel();
            var communicationViewModel = new CommunicationViewModel();

            var memento = GetMemento(loader, serializer);
            memento?.RestoreTo(settingsViewModel);
            memento?.RestoreTo(sendViewModel);

            _postCommandIssuer = new PostCommandIssuer(memento?.RepositoryRoot);
            sendViewModel.Issuer = _postCommandIssuer;
            communicationViewModel.Issuer = _postCommandIssuer;

            _navigationItemToDestinationType = new (NavigationViewItemBase, WindowsControls.Page)[]
            {
                (SendNavigationItem, new SendView(sendViewModel)),
                (CommunicationNavigationItem, new CommunicationView(communicationViewModel)),
                (SettingsNavigationItem, new SettingsView(settingsViewModel)),
            };

            Frame.Navigate(_navigationItemToDestinationType.First().destination);
        }

        private SettingsMemento GetMemento(IFileLoader loader, ISerializer serializer)
        {
            try
            {
                var content = loader.Load("settings");
                return serializer.Deserialize<SettingsMemento>(content);
            }
            catch
            {
                return null; // do nothing, we expect that settings might not exist yet upon first run
            }
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.InvokedItemContainer == LicensesNavigationItem)
            {
                Process.Start(@"Resources\ThirdPartyLicenses.txt");
                return;
            }

            var destination = _navigationItemToDestinationType.FirstOrDefault(dict => dict.NavigationItem == args.InvokedItemContainer).destination;
            if (destination == default)
                throw new ArgumentOutOfRangeException(nameof(args), "Failed to determine destination frame.");

            if (Frame.Content is not null && Frame.Content == destination)
                return;

            Frame.Navigate(destination);
        }

        private void NavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            Frame.GoBack();
        }

        private void Frame_ContentRendered(object sender, EventArgs args)
        {
            var navigationItem = _navigationItemToDestinationType.FirstOrDefault(dict => dict.destination == Frame.Content).NavigationItem;
            NavigationView.SelectedItem = navigationItem ?? throw new InvalidOperationException("Failed to determine selected item.");
        }

        private void Window_Closed(object sender, EventArgs args)
        {
            Dispose();
        }

        public void Dispose()
        {
            _postCommandIssuer.Dispose();
        }
    }
}