using System;

namespace RBTools.Application.Exceptions
{
    public class InvalidSettingsException : Exception
    {
        public InvalidSettingsException()
        {
        }

        public InvalidSettingsException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
