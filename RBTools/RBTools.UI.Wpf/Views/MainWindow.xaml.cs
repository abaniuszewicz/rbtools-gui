using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using Autofac;
using ModernWpf.Controls;
using WindowsControls = System.Windows.Controls;

namespace RBTools.UI.Wpf.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IEnumerable<(NavigationViewItemBase NavigationItem, WindowsControls.Page destination)> _navigationItemToDestinationType;

        public MainWindow(ILifetimeScope scope)
        {
            InitializeComponent();

            _navigationItemToDestinationType = new (NavigationViewItemBase, WindowsControls.Page)[]
            {
                (SendNavigationItem, scope.Resolve<SendView>()),
                (CommunicationNavigationItem, scope.Resolve<CommunicationView>()),
                (SettingsNavigationItem, scope.Resolve<SettingsView>()),
            };

            Frame.Navigate(_navigationItemToDestinationType.First().destination);
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.InvokedItemContainer == LicensesNavigationItem)
            {
                var licensePath = @"Resources\ThirdPartyLicenses.txt";
                Process.Start(new ProcessStartInfo(licensePath) { UseShellExecute = true });
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
    }
}
