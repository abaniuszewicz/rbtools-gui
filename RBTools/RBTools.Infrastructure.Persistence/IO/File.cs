using RBTools.Application.Config.IOAbstractions;
using System;

namespace RBTools.Infrastructure.Persistence.IO
{
    public class File : IFile
    {
        public File(string path)
        {
            Path = path ?? throw new ArgumentNullException(nameof(path));
        }

        public string Path { get; }

        public string Read()
        {
            return System.IO.File.ReadAllText(Path);
        }

        public void Write(string content)
        {
            System.IO.File.WriteAllText(Path, content);
        }

        public void Dispose()
        {
            System.IO.File.Delete(Path);
        }
    }
}
