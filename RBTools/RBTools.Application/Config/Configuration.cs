using RBTools.Application.Config.Exceptions;
using RBTools.Application.Models;
using System;
using System.Collections.Generic;

namespace RBTools.Application.Config
{
    public class Configuration : IConfiguration
    {
        public Configuration()
        {
        }

        public Configuration(IConfigurationManager settingsManager)
        {
            try
            {
                IConfiguration settings = settingsManager.Load();
                ((IConfiguration)this).RestoreFrom(settings);
            }
            catch (Exception exception)
            {
                throw new InvalidSettingsException("Failed to load settings", exception);
            }
        }

        public IEnumerable<AbbreviatedOption> Groups { get; set; }
        public IEnumerable<AbbreviatedOption> People { get; set; }
        public string RepositoryRoot { get; set; }
        public string RepositoryUrl { get; set; }
        public string RepositoryName { get; set; }
        public bool OpenInBrowser { get; set; }
        public bool Publish { get; set; }
        public bool SvnShowCopiesAsAdds { get; set; }
    }
}
