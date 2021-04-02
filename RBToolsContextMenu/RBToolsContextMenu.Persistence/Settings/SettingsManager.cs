using RBToolsContextMenu.Persistence.IO;
using System;
using System.IO;

namespace RBToolsContextMenu.Persistence.Settings
{
    public class SettingsManager : ISettingsLoader, ISettingsSaver
    {
        private readonly IFileSerializer _serializer;
        private readonly string _directory;

        public SettingsManager()
        {
            _serializer = new JsonFileSerializer();
            _directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RBToolsGUI");
        }

        public SettingsManager(IFileSerializer serializer, string directory)
        {
            _serializer = serializer;
            _directory = directory;
        }

        public T Load<T>(string key)
        {
            string path = GetPathFromKey(key);
            return _serializer.Deserialize<T>(path);
        }

        public void Save<T>(T t, string key)
        {
            string path = GetPathFromKey(key);
            _serializer.Serialize(t, path);
        }

        private string GetPathFromKey(string key)
        {
            return Path.Combine(_directory, key);
        }
    }
}
