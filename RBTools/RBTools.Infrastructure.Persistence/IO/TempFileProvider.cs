using RBTools.Application.Config.IOAbstractions;
using System.Collections.Generic;
using System.IO;

namespace RBTools.Infrastructure.Persistence.IO
{
    public class TempFileProvider : ITempFileProvider
    {
        private List<IFile> _tempFiles = new();

        public IFile Create()
        {
            var path = Path.GetTempFileName();
            IFile file = new File(path);
            _tempFiles.Add(file);

            return file;
        }

        public void Dispose()
        {
            _tempFiles.ForEach(f => f.Dispose());
        }
    }
}
