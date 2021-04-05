using System;

namespace RBToolsContextMenu.Persistence.Exceptions
{
    public class UserAbortedActionException : Exception
    {
        public UserAbortedActionException(string message) : base(message)
        {
        }
    }
}
