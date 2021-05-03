using RBTools.Application.Config;
using RBTools.Application.Models;
using RBTools.UI.Wpf.SeedWork;
using RBTools.UI.Wpf.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RBTools.UI.Wpf.ViewModels
{
    public class ConfigurationViewModel : NotifyPropertyChanged, IEquatable<IConfiguration>
    {
        private string _repositoryRoot;
        private string _repositoryUrl;
        private string _repositoryName;
        private bool _openInBrowser;
        private bool _publish;
        private bool _svnShowCopiesAsAdds;

        public ConfigurationViewModel(IConfiguration configuration)
        {
            FromConfiguration(configuration);
        }

        public ObservableCollection<SelectableAbbreviatedOptionViewModel> Groups { get; set; } = new();
        public ObservableCollection<SelectableAbbreviatedOptionViewModel> People { get; set; } = new();

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

        public bool Equals(IConfiguration other)
        {
            var equals = AreEqual(Groups.Select(sao => sao.ToAbbreviatedOption()), other.Groups)
                         && AreEqual(People.Select(sao => sao.ToAbbreviatedOption()), other.People)
                         && (RepositoryRoot ?? string.Empty) == (other.RepositoryRoot ?? string.Empty)
                         && (RepositoryUrl ?? string.Empty) == (other.RepositoryUrl ?? string.Empty)
                         && (RepositoryName ?? string.Empty) == (other.RepositoryName ?? string.Empty)
                         && OpenInBrowser == other.OpenInBrowser
                         && Publish == other.Publish
                         && SvnShowCopiesAsAdds == other.SvnShowCopiesAsAdds;

            return !equals;
        }

        public void FromConfiguration(IConfiguration configuration)
        {
            if (configuration.Groups is not null)
                Groups.ReplaceContentWith(configuration.Groups.Select(ao => new SelectableAbbreviatedOptionViewModel(ao)));
            if (configuration.People is not null)
                People.ReplaceContentWith(configuration.People.Select(ao => new SelectableAbbreviatedOptionViewModel(ao)));
            RepositoryRoot = configuration.RepositoryRoot;
            RepositoryUrl = configuration.RepositoryUrl;
            RepositoryName = configuration.RepositoryName;
            OpenInBrowser = configuration.OpenInBrowser;
            Publish = configuration.Publish;
            SvnShowCopiesAsAdds = configuration.SvnShowCopiesAsAdds;
        }

        public IConfiguration ToConfiguration()
        {
            return new Configuration()
            {
                Groups = Groups.Select(g => g.ToAbbreviatedOption()),
                People = People.Select(p => p.ToAbbreviatedOption()),
                RepositoryRoot = RepositoryRoot,
                RepositoryUrl = RepositoryUrl,
                RepositoryName = RepositoryName,
                OpenInBrowser = OpenInBrowser,
                Publish = Publish,
                SvnShowCopiesAsAdds = SvnShowCopiesAsAdds,
            };
        }

        private static bool AreEqual(IEnumerable<AbbreviatedOption> first, IEnumerable<AbbreviatedOption> second)
        {
            bool isFirstEmpty = first is null || !first.Any();
            bool isSecondEmpty = second is null || !second.Any();
            if (isFirstEmpty ^ isSecondEmpty)
                return false; // only one is empty
            if (isFirstEmpty)
                return true; // both are empty

            return first.SequenceEqual(second);
        }
    }
}
