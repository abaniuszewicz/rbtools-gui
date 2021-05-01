using RBTools.Application.Models;
using System.Collections.Generic;

namespace RBTools.Application.Configuration
{
    public interface ISettings
    {
        public List<AbbreviatedOption> Groups { get; set; }
        public List<AbbreviatedOption> People { get; set; }
        public string RepositoryRoot { get; set; }
        public string RepositoryUrl { get; set; }
        public string RepositoryName { get; set; }
        public bool OpenInBrowser { get; set; }
        public bool Publish { get; set; }
        public bool SvnShowCopiesAsAdds { get; set; }

        public void RestoreFrom(ISettings settings);
    }
}
