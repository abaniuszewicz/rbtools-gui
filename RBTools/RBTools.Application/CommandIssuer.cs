using System;
using RBTools.Application.Communication.Events;
using RBTools.Domain.Commands;

namespace RBTools.Application
{
    public abstract class CommandIssuer : IDisposable
    {
        private readonly CommandProcess _commandProcess;
        
        public event EventHandler<MessageEventArgs> MessageReceived
        {
            add => _commandProcess.MessageReceived += value;
            remove => _commandProcess.MessageReceived -= value;
        } 

        protected CommandIssuer(string root)
        {
            _commandProcess = new CommandProcess(root);
        }

        public void Issue(IRbtCommand command)
        {
            var message = command.Print();
            _commandProcess.Send(message);
        }

        public void Dispose()
        {
           _commandProcess?.Dispose();
        }
    }
}