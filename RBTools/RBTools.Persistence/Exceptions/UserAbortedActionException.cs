using System;

namespace RBTools.Persistence.Exceptions
{
    public class UserAbortedActionException : Exception
    {
        public UserAbortedActionException(string message) : base(message)
        {
        }
    }
}
