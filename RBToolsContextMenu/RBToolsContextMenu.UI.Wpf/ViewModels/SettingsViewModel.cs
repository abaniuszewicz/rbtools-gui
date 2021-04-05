using RBToolsContextMenu.Persistence.Exceptions;
using RBToolsContextMenu.Persistence.IO;
using RBToolsContextMenu.Persistence.Serialization;
using RBToolsContextMenu.UI.Wpf.Models;
using RBToolsContextMenu.UI.Wpf.SeedWork;
using RBToolsContextMenu.UI.Wpf.Utilities.Settings;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RBToolsContextMenu.UI.Wpf.ViewModels
{
    public class SettingsViewModel : NotifyPropertyChanged
    {
        private SettingsMemento _memento;

        private string _repositoryRoot;
        private string _repositoryUrl;
        private string _repositoryName;
        private bool _openInBrowser;
        private bool _publish;
        private bool _svnShowCopiesAsAdds;

        public SettingsViewModel(IFileLoader loader, IFileSaver saver, ISerializer serializer)
        {
            ImportCommand = new RelayCommand<object>(o => Import(loader, serializer));
            ExportCommand = new RelayCommand<object>(o => Export(saver, serializer));
            SaveCommand = new RelayCommand<object>(o => Save(saver, serializer), o => _memento.HasChanged(this));
            _memento = new SettingsMemento(this);
        }

        public ObservableCollection<SelectableText> Groups { get; set; } = new ObservableCollection<SelectableText>();
        public ObservableCollection<SelectableText> People { get; set; } = new ObservableCollection<SelectableText>();

        public ICommand ImportCommand { get; }
        public ICommand ExportCommand { get; }
        public ICommand SaveCommand { get; }

        public string RepositoryRoot
        {
            get => _repositoryRoot;
            set
            {
                if (_repositoryRoot == value) return;
                _repositoryRoot = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SaveCommand));
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
                OnPropertyChanged(nameof(SaveCommand));
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
                OnPropertyChanged(nameof(SaveCommand));
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
                OnPropertyChanged(nameof(SaveCommand));
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
                OnPropertyChanged(nameof(SaveCommand));
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
                OnPropertyChanged(nameof(SaveCommand));
            }
        }

        private void Import(IFileLoader fileLoader, ISerializer serializer)
        {
            string content;

            try
            {
                content = fileLoader.Load();
            }
            catch (UserAbortedActionException)
            {
                return;
            }

            var memento = serializer.Deserialize<SettingsMemento>(content);
            memento.RestoreTo(this);
        }

        private void Export(IFileSaver saver, ISerializer serializer)
        {
            var memento = new SettingsMemento(this);
            string content = serializer.Serialize(memento);
            saver.Save(content);
        }

        private void Save(IFileSaver saver, ISerializer serializer)
        {
            _memento = new SettingsMemento(this);
            string content = serializer.Serialize(_memento);
            saver.Save("settings", content);
        }
    }
}
