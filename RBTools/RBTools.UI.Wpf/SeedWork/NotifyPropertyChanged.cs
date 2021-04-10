using System.ComponentModel;
using System.Runtime.CompilerServices;
using RBTools.UI.Wpf.Properties;

namespace RBTools.UI.Wpf.SeedWork
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