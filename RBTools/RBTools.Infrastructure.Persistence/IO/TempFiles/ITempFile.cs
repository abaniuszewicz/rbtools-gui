using System;

namespace RBTools.Infrastructure.Persistence.IO.TempFiles
{
    public interface ITempFile : IDisposable
    {
        public string Path { get; }

        public string Read();
        public void Write(string content);
    }
}
