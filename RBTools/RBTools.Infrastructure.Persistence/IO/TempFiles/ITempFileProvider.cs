using System;

namespace RBTools.Infrastructure.Persistence.IO.TempFiles
{
    public interface ITempFileProvider : IDisposable
    {
        public ITempFile Create();
    }
}
