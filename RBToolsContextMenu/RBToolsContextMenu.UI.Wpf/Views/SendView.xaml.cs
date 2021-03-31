using RBToolsContextMenu.UI.Wpf.ViewModels;
using System.Windows.Controls;

namespace RBToolsContextMenu.UI.Wpf.Views
{
    public partial class SendView : Page
    {
        public SendView(SendViewModel sendViewModel)
        {
            InitializeComponent();
            DataContext = sendViewModel;
        }
    }
}