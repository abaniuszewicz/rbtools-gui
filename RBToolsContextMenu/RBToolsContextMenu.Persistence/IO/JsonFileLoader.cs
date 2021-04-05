using Microsoft.Win32;
using RBToolsContextMenu.Persistence.Exceptions;
using System.IO;

namespace RBToolsContextMenu.Persistence.IO
{
    public class JsonFileLoader : IFileLoader
    {
        private IPathProvider _pathProvider = new JsonSettingsPathProvider();

        public string Load()
        {
            var dialog = new OpenFileDialog()
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
            };

            var result = dialog.ShowDialog();
            if (!result.HasValue || !result.Value)
                throw new UserAbortedActionException("Load operation was aborted by the user");

            string path = dialog.FileName;
            return File.ReadAllText(path);
        }

        public string Load(string key)
        {
            string path = _pathProvider.GetPathFromKey(key);
            return File.ReadAllText(path);
        }
    }
}
