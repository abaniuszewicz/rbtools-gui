using RBToolsContextMenu.UI.Wpf.ViewModels;
using System.Windows.Controls;

namespace RBToolsContextMenu.UI.Wpf.Views
{
    public partial class SettingsView : Page
    {
        public SettingsView(SettingsViewModel settingsViewModel)
        {
            InitializeComponent();
            DataContext = settingsViewModel;
        }
    }
}