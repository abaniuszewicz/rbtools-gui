using RBToolsContextMenu.UI.Wpf.Models;
using RBToolsContextMenu.UI.Wpf.SeedWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBToolsContextMenu.UI.Wpf.ViewModels
{
    class SettingsViewModel : NotifyPropertyChanged
    {
        private string _repositoryRoot;
        private string _repositoryUrl;
        private string _repositoryName;

        public ObservableCollection<SelectableText> Groups { get; } = new ObservableCollection<SelectableText>();

        public ObservableCollection<SelectableText> People { get; } = new ObservableCollection<SelectableText>();

        public string RepositoryRoot
        {
            get => _repositoryRoot;
            set
            {
                if (_repositoryRoot == value) return;
                _repositoryRoot = value;
                OnPropertyChanged();
            }
        }

        public string RepositoryUrl
        {
            get => _repositoryUrl;
            set
            {
                if (_repositoryUrl == value) return;
                _repositoryUrl = value;
                OnPropertyChanged();
            }
        }

        public string RepositoryName
        {
            get => _repositoryName;
            set
            {
                if (_repositoryName == value) return;
                _repositoryName = value;
                OnPropertyChanged();
            }
        }
    }
}
