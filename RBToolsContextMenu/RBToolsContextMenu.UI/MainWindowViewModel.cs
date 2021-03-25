using System;
using System.Linq;
using System.Windows.Input;
using RBToolsContextMenu.UI.Framework;

namespace RBToolsContextMenu.UI
{
    public sealed class MainWindowViewModel : NotifyPropertyChanged
    {
        private string _consoleInput;
        private string _consoleOutput;
        private string _reviewId;
        private bool _copiesAsAddsChecked;

        public MainWindowViewModel()
        {
            SendCommand = new RelayCommand<object>(o => throw new NotImplementedException());
        }

        public string ConsoleInput
        {
            get => _consoleInput;
            set
            {
                if (value == _consoleInput) return;
                _consoleInput = value;
                OnPropertyChanged();
            }
        }

        public string ConsoleOutput
        {
            get => _consoleOutput;
            set
            {
                if (value == _consoleOutput) return;
                _consoleOutput = value;
                OnPropertyChanged();
            }
        }

        public string ReviewId
        {
            get => _reviewId;
            set
            {
                if (value == _reviewId) return;
                _reviewId = string.Concat(value.Where(char.IsDigit));
                OnPropertyChanged();
            }
        }

        public bool CopiesAsAddsChecked
        {
            get => _copiesAsAddsChecked;
            set
            {
                if (value == _copiesAsAddsChecked) return;
                _copiesAsAddsChecked = value;
                OnPropertyChanged();
            }
        }
        
        public ICommand SendCommand { get; set; }
    }
}