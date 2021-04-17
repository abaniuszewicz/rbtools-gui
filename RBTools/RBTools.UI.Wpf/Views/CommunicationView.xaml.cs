using System.Windows.Controls;
using RBTools.UI.Wpf.ViewModels;

namespace RBTools.UI.Wpf.Views
{
    /// <summary>
    /// Interaction logic for CommunicationView.xaml
    /// </summary>
    public partial class CommunicationView : Page
    {
        public CommunicationView(CommunicationViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
