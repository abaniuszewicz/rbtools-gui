using System;

namespace RBTools.Application.Config.Exceptions
{
    public class UserAbortedFileLoadingException : Exception
    {
        public UserAbortedFileLoadingException(string message) : base(message)
        {
        }
    }
}
