using RBTools.Application.Models;
using System;
using System.Collections.Generic;

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

        public bool HasStateChanged(IEquatable<IConfiguration> current)
        {
            return current.Equals(this);
        }
    }
}
