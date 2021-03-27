using System.ComponentModel;
using System.Runtime.CompilerServices;
using RBToolsContextMenu.UI.Properties;

namespace RBToolsContextMenu.UI.SeedWork
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}