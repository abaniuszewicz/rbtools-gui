using RBTools.Application.Models;
using System.Collections.Generic;
using System.Linq;

namespace RBTools.Application.Configuration
{
    public class SettingsMemento : ISettingsMemento
    {
        public SettingsMemento(ISettings settings)
        {
            RestoreFrom(settings);
        }

        public List<AbbreviatedOption> Groups { get; set; }
        public List<AbbreviatedOption> People { get; set; }
        public string RepositoryRoot { get; set; }
        public string RepositoryUrl { get; set; }
        public string RepositoryName { get; set; }
        public bool OpenInBrowser { get; set; }
        public bool Publish { get; set; }
        public bool SvnShowCopiesAsAdds { get; set; }

        public bool HasStateChanged(ISettings current)
        {
            var equals = AreEqual(Groups, current.Groups)
                         && AreEqual(People, current.People)
                         && (RepositoryRoot ?? string.Empty) == (current.RepositoryRoot ?? string.Empty)
                         && (RepositoryUrl ?? string.Empty) == (current.RepositoryUrl ?? string.Empty)
                         && (RepositoryName ?? string.Empty) == (current.RepositoryName ?? string.Empty)
                         && OpenInBrowser == current.OpenInBrowser
                         && Publish == current.Publish
                         && SvnShowCopiesAsAdds == current.SvnShowCopiesAsAdds;

            return !equals;
        }

        public void RestoreFrom(ISettings settings)
        {
            if (settings is null)
                return;

            Groups = settings.Groups?.Select(g => g?.DeepCopy()).ToList();
            People = settings.People?.Select(p => p?.DeepCopy()).ToList();
            RepositoryRoot = settings.RepositoryRoot;
            RepositoryUrl = settings.RepositoryUrl;
            RepositoryName = settings.RepositoryName;
            OpenInBrowser = settings.OpenInBrowser;
            Publish = settings.Publish;
            SvnShowCopiesAsAdds = settings.SvnShowCopiesAsAdds;
        }

        private static bool AreEqual(List<AbbreviatedOption> first, List<AbbreviatedOption> second)
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
