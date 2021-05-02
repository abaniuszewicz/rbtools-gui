using RBTools.Application.Models;
using RBTools.UI.Wpf.SeedWork;

namespace RBTools.UI.Wpf.ViewModels
{
    public class SelectableAbbreviatedOptionViewModel : NotifyPropertyChanged
    {
        private string _abbreviation;
        private string _value;
        private bool _isSelected;

        public SelectableAbbreviatedOptionViewModel()
        {
        }

        public SelectableAbbreviatedOptionViewModel(AbbreviatedOption abbreviatedOption)
        {
            FromAbbreviatedOption(abbreviatedOption);
        }

        public string Abbreviation
        {
            get => _abbreviation;
            set
            {
                if (_abbreviation == value) return;
                _abbreviation = value;
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

        public AbbreviatedOption ToAbbreviatedOption()
        {
            return new AbbreviatedOption()
            {
                Abbreviation = Abbreviation,
                Value = Value,
            };
        }

        public void FromAbbreviatedOption(AbbreviatedOption abbreviatedOption)
        {
            Abbreviation = abbreviatedOption.Abbreviation;
            Value = abbreviatedOption.Value;
        }
    }
}
