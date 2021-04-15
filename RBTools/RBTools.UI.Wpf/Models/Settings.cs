using System.Collections.ObjectModel;
using RBTools.UI.Wpf.SeedWork;
using RBTools.UI.Wpf.Utilities;

namespace RBTools.UI.Wpf.Models
{
    public class Settings : NotifyPropertyChanged
    {
        private string _repositoryRoot;
        private string _repositoryUrl;
        private string _repositoryName;
        private bool _openInBrowser;
        private bool _publish;
        private bool _svnShowCopiesAsAdds;

        public void RestoreFrom(Settings other)
        {
            RepositoryRoot = other.RepositoryRoot;
            RepositoryUrl = other.RepositoryUrl;
            RepositoryName = other.RepositoryName;
            OpenInBrowser = other.OpenInBrowser;
            Publish = other.Publish;
            SvnShowCopiesAsAdds = other.SvnShowCopiesAsAdds;
            Groups.ReplaceContentWith(other.Groups);
            People.ReplaceContentWith(other.People);
        }
        
        public ObservableCollection<SelectableText> Groups { get; set; } = new ObservableCollection<SelectableText>();
        public ObservableCollection<SelectableText> People { get; set; } = new ObservableCollection<SelectableText>();

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