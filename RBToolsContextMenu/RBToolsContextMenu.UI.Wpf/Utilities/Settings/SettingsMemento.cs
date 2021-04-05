using RBToolsContextMenu.UI.Wpf.Models;
using RBToolsContextMenu.UI.Wpf.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RBToolsContextMenu.UI.Wpf.Utilities.Settings
{
    public class SettingsMemento
    {
        public IEnumerable<SelectableText> Groups { get; init; } = Enumerable.Empty<SelectableText>();
        public IEnumerable<SelectableText> People { get; init; } = Enumerable.Empty<SelectableText>();
        public string RepositoryRoot { get; init; }
        public string RepositoryUrl { get; init; }
        public string RepositoryName { get; init; }
        public bool OpenInBrowser { get; init; }
        public bool Publish { get; init; }
        public bool SvnShowCopiesAsAdds { get; init; }

        public SettingsMemento()
        {
        }

        public SettingsMemento(SettingsViewModel settings)
        {
            Groups = settings.Groups.Select(g => g.DeepCopy()).ToList();
            People = settings.People.Select(p => p.DeepCopy()).ToList();
            RepositoryRoot = settings.RepositoryRoot;
            RepositoryUrl = settings.RepositoryUrl;
            RepositoryName = settings.RepositoryName;
            OpenInBrowser = settings.OpenInBrowser;
            Publish = settings.Publish;
            SvnShowCopiesAsAdds = settings.SvnShowCopiesAsAdds;
        }

        public void RestoreTo(SettingsViewModel settings)
        {
            settings.Groups = new ObservableCollection<SelectableText>(Groups.Select(g => g.DeepCopy()));
            settings.People = new ObservableCollection<SelectableText>(People.Select(p => p.DeepCopy()));
            settings.RepositoryRoot = RepositoryRoot;
            settings.RepositoryUrl = RepositoryUrl;
            settings.RepositoryName = RepositoryName;
            settings.OpenInBrowser = OpenInBrowser;
            settings.Publish = Publish;
            settings.SvnShowCopiesAsAdds = SvnShowCopiesAsAdds;
        }

        public void RestoreTo(SendViewModel send)
        {
            send.Groups = new ObservableCollection<SelectableText>(Groups.Select(g => g.DeepCopy()));
            send.People = new ObservableCollection<SelectableText>(People.Select(p => p.DeepCopy()));
            send.Root = RepositoryRoot;
            send.Server = RepositoryUrl;
            send.Repository = RepositoryName;
            send.OpenInBrowser = OpenInBrowser;
            send.Publish = Publish;
            send.SvnShowCopiesAsAdds = SvnShowCopiesAsAdds;

        }

        public bool HasChanged(SettingsViewModel settings)
        {
            bool equals = Groups.SequenceEqual(settings.Groups)
                && People.SequenceEqual(settings.People)
                && (RepositoryRoot ?? string.Empty) == (settings.RepositoryRoot ?? string.Empty)
                && (RepositoryUrl ?? string.Empty) == (settings.RepositoryUrl ?? string.Empty)
                && (RepositoryName ?? string.Empty) == (settings.RepositoryName ?? string.Empty)
                && OpenInBrowser == settings.OpenInBrowser
                && Publish == settings.Publish
                && SvnShowCopiesAsAdds == settings.SvnShowCopiesAsAdds;

            return !equals;
        }
    }
}
