using RBToolsContextMenu.UI.Wpf.SeedWork;

namespace RBToolsContextMenu.UI.Wpf.Models
{
    public class SelectableText : NotifyPropertyChanged
    {
        private string _display;
        private string _value;
        private bool _isSelected;

        public string Display
        {
            get => _display;
            set
            {
                if (_display == value) return;
                _display = value;
                OnPropertyChanged();
            }
        }

        public string Value
        {
            get => _value;
            set
            {
                if (_value == value) return;
                _value = value;
                OnPropertyChanged();
            }
        }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected == value) return;
                _isSelected = value;
                OnPropertyChanged();
            }
        }
    }
}
