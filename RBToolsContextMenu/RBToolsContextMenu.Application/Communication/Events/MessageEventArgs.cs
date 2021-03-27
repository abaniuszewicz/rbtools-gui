using System;

namespace RBToolsContextMenu.Application.Communication.Events
{
    public class MessageEventArgs : EventArgs
    {
        public string Message { get; }

        public MessageEventArgs(string message)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }
        
        public static implicit operator MessageEventArgs(string message)
        {
            return new MessageEventArgs(message);
        }
    }
}