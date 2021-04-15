using System;

namespace RBTools.Infrastructure.Persistence.Exceptions
{
    public class UserAbortedActionException : Exception
    {
        public UserAbortedActionException(string message) : base(message)
        {
        }
    }
}
