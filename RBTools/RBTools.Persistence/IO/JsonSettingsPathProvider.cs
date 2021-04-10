using System;
using System.IO;

namespace RBTools.Persistence.IO
{
    internal class JsonSettingsPathProvider : IPathProvider
    {
        public string Directory { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RBToolsGUI");

        public string GetPathFromKey(string key)
        {
            return Path.Combine(Directory, $"{key}.json");
        }
    }
}
