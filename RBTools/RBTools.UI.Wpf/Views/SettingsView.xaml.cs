using System.Windows.Controls;
using RBTools.UI.Wpf.ViewModels;

namespace RBTools.UI.Wpf.Views
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