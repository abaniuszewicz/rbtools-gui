using RBTools.Infrastructure.Persistence.Exceptions;

namespace RBTools.Infrastructure.Persistence.IO
{
    public interface IFileLoader
    {
        public string Load(string key);

        /// <exception cref="UserAbortedActionException"/>
        public string Load();
    }
}
