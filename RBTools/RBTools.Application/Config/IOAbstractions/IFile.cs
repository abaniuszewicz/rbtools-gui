using System;

namespace RBTools.Application.Config.IOAbstractions
{
    public interface IFile : IDisposable
    {
        public string Path { get; }

        public string Read();
        public void Write(string content);
    }
}
