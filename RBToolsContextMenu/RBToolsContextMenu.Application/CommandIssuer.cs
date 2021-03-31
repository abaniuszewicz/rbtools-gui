using System;
using RBToolsContextMenu.Application.Communication.Events;
using RBToolsContextMenu.Domain.Commands;

namespace RBToolsContextMenu.Application
{
    public abstract class CommandIssuer : IDisposable
    {
        private readonly CommandProcess _commandProcess;
        
        public event EventHandler<MessageEventArgs> MessageReceived
        {
            add => _commandProcess.MessageReceived += value;
            remove => _commandProcess.MessageReceived -= value;
        } 

        protected CommandIssuer()
        {
            _commandProcess = new CommandProcess();
        }

        public void Issue(IRbtCommand command)
        {
            var message = command.Print();
            _commandProcess.Send(message);
        }

        public void Dispose()
        {
           // _commandProcess?.Dispose();
        }
    }
}