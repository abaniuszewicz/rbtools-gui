using System;
using RBToolsContextMenu.Application.Communication.Events;
using RBToolsContextMenu.Domain.Commands;

namespace RBToolsContextMenu.Application
{
    public abstract class CommandIssuer : IDisposable
    {
        private readonly CommandProcess _commandProcess;
        private readonly IRbtCommand _command;
        
        public event EventHandler<MessageEventArgs> MessageSent
        {
            add => _commandProcess.MessageSent += value;
            remove => _commandProcess.MessageSent -= value;
        } 
        
        public event EventHandler<MessageEventArgs> MessageReceived
        {
            add => _commandProcess.MessageReceived += value;
            remove => _commandProcess.MessageReceived -= value;
        } 

        protected CommandIssuer(IRbtCommand command)
        {
            _commandProcess = new CommandProcess();
            _command = command;
        }

        public void Issue()
        {
            var message = _command.Print();
            _commandProcess.Send(message);
        }

        public void Dispose()
        {
            _commandProcess?.Dispose();
        }
    }
}