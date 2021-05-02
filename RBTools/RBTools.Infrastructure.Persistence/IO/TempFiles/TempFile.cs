using System;
using System.IO;

namespace RBTools.Infrastructure.Persistence.IO.TempFiles
{
    public class TempFile : ITempFile
    {
        public TempFile(string path)
        {
            Path = path ?? throw new ArgumentNullException(nameof(path));
        }

        public string Path { get; }

        public string Read()
        {
            return File.ReadAllText(Path);
        }

        public void Write(string content)
        {
            File.WriteAllText(Path, content);
        }

        public void Dispose()
        {
            File.Delete(Path);
        }
    }
}
