using RBTools.Application.Config;
using RBTools.Infrastructure.Persistence.IO;
using RBTools.Infrastructure.Persistence.Serialization;

namespace RBTools.Infrastructure.Persistence
{
    public class ConfigurationManager : IConfigurationManager
    {
        private const string Filename = "settings";
        private readonly IConfiguration _configuration;
        private readonly IFileLoadSave _fileLoadSave;
        private readonly ISerializer _serializer;

        public ConfigurationManager(IConfiguration configuration, IFileLoadSave fileLoadSave, ISerializer serializer)
        {
            _configuration = configuration;
            _fileLoadSave = fileLoadSave;
            _serializer = serializer;

            IConfiguration persistedConfig = Load();
            if (persistedConfig != null)
                _configuration.RestoreFrom(persistedConfig);
        }

        public IConfiguration Load()
        {
            try
            {
                string content = _fileLoadSave.Load(Filename);
                return _serializer.Deserialize<Configuration>(content);
            }
            catch // TODO
            {
                return null;
            }
        }

        public void Save(IConfiguration settings)
        {
            string content = _serializer.Serialize(settings);
            _fileLoadSave.Save(Filename, content);
        }

        public IConfiguration Import()
        {
            try
            {
                string content = _fileLoadSave.Load();
                return _serializer.Deserialize<Configuration>(content);
            }
            catch // TODO
            {
                return null;
            }
        }

        public void Export(IConfiguration settings)
        {
            string content = _serializer.Serialize(settings);
            _fileLoadSave.Save(content);
        }
    }
}
