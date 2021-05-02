using RBTools.Application.Config;
using RBTools.Infrastructure.Persistence.IO;
using RBTools.Infrastructure.Persistence.Serialization;

namespace RBTools.Infrastructure.Persistence
{
    public class SettingsManager : IConfigurationManager
    {
        private const string Filename = "settings";
        private readonly IFileLoadSave _fileLoadSave;
        private readonly ISerializer _serializer;

        public SettingsManager(IFileLoadSave fileLoadSave, ISerializer serializer)
        {
            _fileLoadSave = fileLoadSave;
            _serializer = serializer;
        }

        public IConfiguration Load()
        {
            string content = _fileLoadSave.Load(Filename);
            return _serializer.Deserialize<Configuration>(content);
        }

        public void Save(IConfiguration settings)
        {
            string content = _serializer.Serialize(settings);
            _fileLoadSave.Save(Filename, content);
        }

        public IConfiguration Import()
        {
            string content = _fileLoadSave.Load();
            return _serializer.Deserialize<Configuration>(content);
        }

        public void Export(IConfiguration settings)
        {
            string content = _serializer.Serialize(settings);
            _fileLoadSave.Save(content);
        }
    }
}
