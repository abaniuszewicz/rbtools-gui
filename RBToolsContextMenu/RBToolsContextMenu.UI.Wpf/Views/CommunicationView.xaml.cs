using RBToolsContextMenu.UI.Wpf.ViewModels;
using System.Windows.Controls;

namespace RBToolsContextMenu.UI.Wpf.Views
{
    public partial class CommunicationView : Page
    {
        public CommunicationView(CommunicationViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}