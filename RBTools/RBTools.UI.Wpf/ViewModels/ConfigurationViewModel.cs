using RBTools.Application.Config;
using RBTools.Application.Models;
using RBTools.UI.Wpf.SeedWork;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RBTools.UI.Wpf.ViewModels
{
    public class ConfigurationViewModel : NotifyPropertyChanged, IConfiguration
    {
        private readonly IConfiguration _configuration;

        public ConfigurationViewModel(IConfiguration configuration)
        {
            _configuration = configuration;
            ((IConfiguration)this).RestoreFrom(configuration);
        }

        public ObservableCollection<SelectableAbbreviatedOptionViewModel> SelectableGroups { get; set; } = new();
        public ObservableCollection<SelectableAbbreviatedOptionViewModel> SelectablePeople { get; set; } = new();

        public IEnumerable<AbbreviatedOption> Groups
        {
            get => SelectableGroups.Select(g => g.ToAbbreviatedOption()).ToArray();
            set => ReplaceContent(SelectableGroups, value.Select(ao => new SelectableAbbreviatedOptionViewModel(ao)));
        }

        public IEnumerable<AbbreviatedOption> People
        {
            get => SelectablePeople.Select(p => p.ToAbbreviatedOption()).ToArray();
            set => ReplaceContent(SelectablePeople, value.Select(ao => new SelectableAbbreviatedOptionViewModel(ao)));
        }

        public string RepositoryRoot
        {
            get => _configuration.RepositoryRoot;
            set
            {
                if (_configuration.RepositoryRoot == value) return;
                _configuration.RepositoryRoot = value;
                OnPropertyChanged();
            }
        }

        public string RepositoryUrl
        {
            get => _configuration.RepositoryUrl;
            set
            {
                if (_configuration.RepositoryUrl == value) return;
                _configuration.RepositoryUrl = value;
                OnPropertyChanged();
            }
        }

        public string RepositoryName
        {
            get => _configuration.RepositoryName;
            set
            {
                if (_configuration.RepositoryName == value) return;
                _configuration.RepositoryName = value;
                OnPropertyChanged();
            }
        }

        public bool OpenInBrowser
        {
            get => _configuration.OpenInBrowser;
            set
            {
                if (_configuration.OpenInBrowser == value) return;
                _configuration.OpenInBrowser = value;
                OnPropertyChanged();
            }
        }

        public bool Publish
        {
            get => _configuration.Publish;
            set
            {
                if (_configuration.Publish == value) return;
                _configuration.Publish = value;
                OnPropertyChanged();
            }
        }

        public bool SvnShowCopiesAsAdds
        {
            get => _configuration.SvnShowCopiesAsAdds;
            set
            {
                if (_configuration.SvnShowCopiesAsAdds == value) return;
                _configuration.SvnShowCopiesAsAdds = value;
                OnPropertyChanged();
            }
        }

        private static void ReplaceContent<T>(ObservableCollection<T> original, IEnumerable<T> replacements)
        {
            original.Clear();
            foreach (var replacement in replacements)
                original.Add(replacement);
        }
    }
}
