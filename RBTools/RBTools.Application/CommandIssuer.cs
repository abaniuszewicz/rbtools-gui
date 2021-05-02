using System;
using RBTools.Application.Communication.Events;
using RBTools.Application.Config;
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

        protected CommandIssuer(IConfiguration settings)
        {
            _commandProcess = new CommandProcess(settings.RepositoryRoot);
        }

        protected void Issue(IRbtCommand command)
        {
            var message = command.Print();
            _commandProcess.Send(message);
        }

        public virtual void Dispose()
        {
           _commandProcess?.Dispose();
        }
    }
}