using Microsoft.Win32;
using System.IO;

namespace RBToolsContextMenu.Persistence.IO
{
    public class JsonFileSaver : IFileSaver
    {
        private IPathProvider _pathProvider = new JsonSettingsPathProvider();

        public void Save(string content)
        {
            var dialog = new SaveFileDialog()
            {
                Filter = "JSON files (*.json)|*.json",
            };

            var result = dialog.ShowDialog();
            if (!result.HasValue || !result.Value)
                return;

            File.WriteAllText(dialog.FileName, content);
        }

        public void Save(string key, string content)
        {
            var path = _pathProvider.GetPathFromKey(key);
            Directory.CreateDirectory(_pathProvider.Directory);
            File.WriteAllText(path, content);
        }
    }
}
