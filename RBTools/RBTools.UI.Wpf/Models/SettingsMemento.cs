using System.Collections.Generic;
using System.Linq;

namespace RBTools.UI.Wpf.Models
{
    public class SettingsMemento
    {
        public IEnumerable<SelectableText> Groups { get; }
        public IEnumerable<SelectableText> People { get; }
        public string RepositoryRoot { get; }
        public string RepositoryUrl { get; }
        public string RepositoryName { get; }
        public bool OpenInBrowser { get; }
        public bool Publish { get; }
        public bool SvnShowCopiesAsAdds { get; }

        public SettingsMemento(Settings settings)
        {
            if (settings is null)
                return;
            
            Groups = settings.Groups?.Select(g => g.DeepCopy()).ToList();
            People = settings.People?.Select(p => p.DeepCopy()).ToList();
            RepositoryRoot = settings.RepositoryRoot;
            RepositoryUrl = settings.RepositoryUrl;
            RepositoryName = settings.RepositoryName;
            OpenInBrowser = settings.OpenInBrowser;
            Publish = settings.Publish;
            SvnShowCopiesAsAdds = settings.SvnShowCopiesAsAdds;
        }

        public bool HasChanged(Settings settings)
        {
            var x = Groups.SequenceEqual(settings.Groups);
            var y = People.SequenceEqual(settings.People);
            var equals = Groups.SequenceEqual(settings.Groups)
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
