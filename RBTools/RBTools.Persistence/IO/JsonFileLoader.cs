using System.IO;
using Microsoft.Win32;
using RBTools.Persistence.Exceptions;

namespace RBTools.Persistence.IO
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

            var path = dialog.FileName;
            return File.ReadAllText(path);
        }

        public string Load(string key)
        {
            var path = _pathProvider.GetPathFromKey(key);
            return File.ReadAllText(path);
        }
    }
}
