using System;

namespace RBTools.Application.Config.Exceptions
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
