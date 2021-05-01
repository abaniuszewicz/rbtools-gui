using RBTools.Application.Configuration;
using RBTools.Infrastructure.Persistence.IO;
using RBTools.Infrastructure.Persistence.Serialization;

namespace RBTools.Infrastructure.Persistence.Settings
{
    public class SettingsManager : ISettingsManager
    {
        private const string Filename = "settings";
        private readonly IFileManager _fileManager;
        private readonly ISerializer _serializer;

        public SettingsManager(IFileManager fileManager, ISerializer serializer)
        {
            _fileManager = fileManager;
            _serializer = serializer;
        }

        public ISettings Load()
        {
            string content = _fileManager.Load(Filename);
            return _serializer.Deserialize<ISettings>(content);
        }

        public void Save(ISettings settings)
        {
            string content = _serializer.Serialize(settings);
            _fileManager.Save(Filename, content);
        }

        public ISettings Import()
        {
            string content = _fileManager.Load();
            return _serializer.Deserialize<ISettings>(content);
        }

        public void Export(ISettings settings)
        {
            string content = _serializer.Serialize(settings);
            _fileManager.Save(content);
        }
    }
}
