using System.Windows.Controls;
using RBTools.UI.Wpf.ViewModels;

namespace RBTools.UI.Wpf.Views
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