using RBTools.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RBTools.Application.Config
{
    public class ConfigurationMemento : IConfigurationMemento
    {
        public ConfigurationMemento(IConfiguration settings)
        {
            ((IConfiguration)this).RestoreFrom(settings);
        }

        public IEnumerable<AbbreviatedOption> Groups { get; set; }
        public IEnumerable<AbbreviatedOption> People { get; set; }
        public string RepositoryRoot { get; set; }
        public string RepositoryUrl { get; set; }
        public string RepositoryName { get; set; }
        public bool OpenInBrowser { get; set; }
        public bool Publish { get; set; }
        public bool SvnShowCopiesAsAdds { get; set; }

        public bool HasStateChanged(IConfiguration current)
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
