using System.Windows.Controls;
using RBTools.UI.Wpf.ViewModels;

namespace RBTools.UI.Wpf.Views
{
    /// <summary>
    /// Interaction logic for SendView.xaml
    /// </summary>
    public partial class SendView : Page
    {
        public SendView(SendViewModel sendViewModel)
        {
            InitializeComponent();
            DataContext = sendViewModel;
        }
    }
}
