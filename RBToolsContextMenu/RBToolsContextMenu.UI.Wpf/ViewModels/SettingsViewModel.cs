using RBToolsContextMenu.UI.Wpf.Models;
using RBToolsContextMenu.UI.Wpf.SeedWork;
using System.Collections.ObjectModel;

namespace RBToolsContextMenu.UI.Wpf.ViewModels
{
    class SettingsViewModel : NotifyPropertyChanged
    {
        private string _repositoryRoot;
        private string _repositoryUrl;
        private string _repositoryName;
        private bool _openInBrowser;
        private bool _publish;
        private bool _svnShowCopiesAsAdds;

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

        public bool OpenInBrowser
        {
            get => _openInBrowser;
            set
            {
                if (_openInBrowser == value) return;
                _openInBrowser = value;
                OnPropertyChanged();
            }
        }

        public bool Publish
        {
            get => _publish;
            set
            {
                if (_publish == value) return;
                _publish = value;
                OnPropertyChanged();
            }
        }

        public bool SvnShowCopiesAsAdds
        {
            get => _svnShowCopiesAsAdds;
            set
            {
                if (_svnShowCopiesAsAdds == value) return;
                _svnShowCopiesAsAdds = value;
                OnPropertyChanged();
            }
        }
    }
}
