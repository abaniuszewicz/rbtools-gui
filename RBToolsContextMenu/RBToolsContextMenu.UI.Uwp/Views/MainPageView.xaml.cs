using WindowsUI = Windows.UI.Xaml.Controls;
using MicrosoftUI = Microsoft.UI.Xaml.Controls;
using System;
using RBToolsContextMenu.UI.Uwp.Views;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.ViewManagement;
using Windows.Foundation;

namespace RBToolsContextMenu.UI.Uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : WindowsUI.Page
    {
        private readonly IEnumerable<(MicrosoftUI.NavigationViewItemBase NavigationItem, Type DestinationType)> _navigationItemToDestinationType;

        public MainPage()
        {
            ApplicationView.PreferredLaunchViewSize = new Size(800, 600);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            this.InitializeComponent();

            _navigationItemToDestinationType = new(MicrosoftUI.NavigationViewItemBase, Type)[]
            {
                (SendNavigationItem, typeof(SendView)),
                (CommunicationNavigationItem, typeof(CommunicationView)),
                (SettingsNavigationItem, typeof(SettingsView)),
            };

            Frame.Navigate(_navigationItemToDestinationType.First().DestinationType);
            UpdateSelectedItem();
        }

        private void NavigationView_ItemInvoked(MicrosoftUI.NavigationView sender, MicrosoftUI.NavigationViewItemInvokedEventArgs args)
        {
            Type destination = _navigationItemToDestinationType.FirstOrDefault(dict => dict.NavigationItem == args.InvokedItemContainer).DestinationType;
            if (destination == default)
                throw new ArgumentOutOfRangeException(nameof(args), "Failed to determine destination frame.");

            if (Frame.Content is not null && Frame.Content.GetType() == destination)
                return;

            Frame.Navigate(destination);
        }

        private void NavigationView_BackRequested(MicrosoftUI.NavigationView sender, MicrosoftUI.NavigationViewBackRequestedEventArgs args)
        {
            Frame.GoBack();
            UpdateSelectedItem();
        }

        private void UpdateSelectedItem()
        {
            Type currentType = Frame.Content.GetType();
            MicrosoftUI.NavigationViewItemBase navigationItem = _navigationItemToDestinationType.FirstOrDefault(dict => dict.DestinationType == currentType).NavigationItem;
            NavigationView.SelectedItem = navigationItem ?? throw new InvalidOperationException("Failed to determine selected item.");
        }
    }
}
