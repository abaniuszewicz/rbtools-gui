using RBToolsContextMenu.Persistence.Exceptions;

namespace RBToolsContextMenu.Persistence.IO
{
    public interface IFileLoader
    {
        public string Load(string key);

        /// <exception cref="UserAbortedActionException"/>
        public string Load();
    }
}
