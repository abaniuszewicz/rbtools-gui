using System;
using System.Collections.Generic;
using System.Linq;
using ModernWpf.Controls;
using RBToolsContextMenu.UI.Wpf.Views;

using WindowsControls = System.Windows.Controls;

namespace RBToolsContextMenu.UI.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly IEnumerable<(NavigationViewItemBase NavigationItem, WindowsControls.Page destination)> _navigationItemToDestinationType;

        public MainWindow()
        {
            InitializeComponent();

            _navigationItemToDestinationType = new(NavigationViewItemBase, WindowsControls.Page)[]
            {
                (SendNavigationItem, new SendView()),
                (CommunicationNavigationItem, new CommunicationView()),
                (SettingsNavigationItem, new SettingsView()),
            };

            var x = _navigationItemToDestinationType.First().destination;
            Frame.Navigate(x);
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
    }
}