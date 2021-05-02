using System.Collections.Generic;
using System.IO;

namespace RBTools.Infrastructure.Persistence.IO.TempFiles
{
    public class TempFileProvider : ITempFileProvider
    {
        private List<ITempFile> _tempFiles = new();

        public ITempFile Create()
        {
            var path = Path.GetTempFileName();
            ITempFile file = new TempFile(path);
            _tempFiles.Add(file);

            return file;
        }

        public void Dispose()
        {
            _tempFiles.ForEach(f => f.Dispose());
        }
    }
}
