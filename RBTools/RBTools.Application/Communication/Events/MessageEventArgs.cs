using System;

namespace RBTools.Application.Communication.Events
{
    public class MessageEventArgs : EventArgs
    {
        public string Message { get; }

        public MessageEventArgs(string message)
        {
            Message = message;
        }
        
        public static implicit operator MessageEventArgs(string message)
        {
            return new MessageEventArgs(message);
        }
    }
}