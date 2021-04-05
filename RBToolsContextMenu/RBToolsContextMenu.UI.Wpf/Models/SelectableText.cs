using RBToolsContextMenu.UI.Wpf.SeedWork;
using System;

namespace RBToolsContextMenu.UI.Wpf.Models
{
    public class SelectableText : NotifyPropertyChanged, IEquatable<SelectableText>
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

        public SelectableText DeepCopy()
        {
            return new SelectableText()
            {
                Display = Display,
                Value = Value,
                IsSelected = IsSelected,
            };
        }

        public bool Equals(SelectableText other)
        {
            return (Display ?? string.Empty) == (other.Display ?? string.Empty)
                && (Value ?? string.Empty) == (other.Value ?? string.Empty)
                && IsSelected == other.IsSelected;
        }

        public override bool Equals(object obj)
        {
            return obj is SelectableText selectableText && Equals(selectableText);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Display?.GetHashCode() ?? 0;
                hash = hash * 23 + Value?.GetHashCode() ?? 0;
                hash = hash * 23 + IsSelected.GetHashCode();
                return hash;
            }
        }
    }
}
