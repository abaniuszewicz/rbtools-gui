using System;

namespace RBTools.Application.Config.IOAbstractions
{
    public interface ITempFileProvider : IDisposable
    {
        public IFile Create();
    }
}
