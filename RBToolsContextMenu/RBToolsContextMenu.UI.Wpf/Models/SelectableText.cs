using RBToolsContextMenu.UI.Wpf.SeedWork;

namespace RBToolsContextMenu.UI.Wpf.Models
{
    public class SelectableText : NotifyPropertyChanged
    {
        private string _text;
        private bool _isSelected;

        public SelectableText(string text)
        {
            Text = text;
        }

        public SelectableText(string text, bool isSelected)
        {
            Text = text;
            IsSelected = isSelected;
        }

        public string Text
        {
            get => _text;
            set
            {
                if (_text == value) return;
                _text = value;
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
