using Microsoft.Win32;
using RBTools.Application.Config.Exceptions;
using System;
using System.IO;

namespace RBTools.Infrastructure.Persistence.IO
{
    public class JsonFileLoadSave : IFileLoadSave
    {
        private static readonly string Directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RBToolsGUI");

        public string Load(string filename)
        {
            var path = GetPathFromFilename(filename);
            return System.IO.File.ReadAllText(path);
        }

        public string Load()
        {
            var dialog = new OpenFileDialog()
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
            };

            var result = dialog.ShowDialog();
            if (!result.HasValue || !result.Value)
                throw new UserAbortedFileLoadingException("Load operation was aborted by the user");

            return System.IO.File.ReadAllText(dialog.FileName);
        }

        public void Save(string filename, string content)
        {
            var path = GetPathFromFilename(filename);
            System.IO.Directory.CreateDirectory(Directory);
            System.IO.File.WriteAllText(path, content);
        }

        public void Save(string content)
        {
            var dialog = new SaveFileDialog()
            {
                Filter = "JSON files (*.json)|*.json",
                FileName = "file.json",
            };

            var result = dialog.ShowDialog();
            if (!result.HasValue || !result.Value)
                return;

            System.IO.File.WriteAllText(dialog.FileName, content);
        }

        public static string GetPathFromFilename(string filename)
        {
            return Path.Combine(Directory, $"{filename}.json");
        }
    }
}
