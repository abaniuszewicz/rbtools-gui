using RBTools.Persistence.Exceptions;

namespace RBTools.Persistence.IO
{
    public interface IFileLoader
    {
        public string Load(string key);

        /// <exception cref="UserAbortedActionException"/>
        public string Load();
    }
}
