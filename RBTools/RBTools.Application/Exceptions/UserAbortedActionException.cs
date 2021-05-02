using System;

namespace RBTools.Application.Exceptions
{
    public class UserAbortedActionException : Exception
    {
        public UserAbortedActionException(string message) : base(message)
        {
        }
    }
}
