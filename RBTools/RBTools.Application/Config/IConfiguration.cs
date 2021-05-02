using RBTools.Application.Models;
using System.Collections.Generic;
using System.Linq;

namespace RBTools.Application.Config
{
    public interface IConfiguration
    {
        public IEnumerable<AbbreviatedOption> Groups { get; set; }
        public IEnumerable<AbbreviatedOption> People { get; set; }
        public string RepositoryRoot { get; set; }
        public string RepositoryUrl { get; set; }
        public string RepositoryName { get; set; }
        public bool OpenInBrowser { get; set; }
        public bool Publish { get; set; }
        public bool SvnShowCopiesAsAdds { get; set; }

        public void RestoreFrom(IConfiguration settings)
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
    }
}
