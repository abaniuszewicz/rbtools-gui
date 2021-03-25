using System.ComponentModel;
using System.Runtime.CompilerServices;
using RBToolsContextMenu.UI.Annotations;

namespace RBToolsContextMenu.UI.Framework
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