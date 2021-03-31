using System;
using System.Collections.Generic;
using System.Linq;
using ModernWpf.Controls;
using RBToolsContextMenu.Application;
using RBToolsContextMenu.UI.Wpf.Settings;
using RBToolsContextMenu.UI.Wpf.ViewModels;
using RBToolsContextMenu.UI.Wpf.Views;

using WindowsControls = System.Windows.Controls;

namespace RBToolsContextMenu.UI.Wpf
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
            _postCommandIssuer = new();
            SendViewModel sendViewModel = SettingsLoader.LoadSendViewModel();
            sendViewModel.Issuer = _postCommandIssuer;

            _navigationItemToDestinationType = new (NavigationViewItemBase, WindowsControls.Page)[]
            {
                (SendNavigationItem, new SendView(sendViewModel)),
                (CommunicationNavigationItem, new CommunicationView(new CommunicationViewModel() { Issuer = _postCommandIssuer })),
                (SettingsNavigationItem, new SettingsView()),
            };

            Frame.Navigate(_navigationItemToDestinationType.First().destination);
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
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

        private void Frame_ContentRendered(object sender, EventArgs e)
        {
            var navigationItem = _navigationItemToDestinationType.FirstOrDefault(dict => dict.destination == Frame.Content).NavigationItem;
            NavigationView.SelectedItem = navigationItem ?? throw new InvalidOperationException("Failed to determine selected item.");
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Dispose();
        }

        public void Dispose()
        {
            _postCommandIssuer.Dispose();
        }
    }
}