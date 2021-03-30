using RBToolsContextMenu.UI.Wpf.Models;
using RBToolsContextMenu.UI.Wpf.SeedWork;

namespace RBToolsContextMenu.UI.Wpf.ViewModels
{
    public class CommunicationViewModel : NotifyPropertyChanged
    {
        public PostCommandIssuer Issuer { get; set; } = PostCommandIssuer.Instance;
    }
}
