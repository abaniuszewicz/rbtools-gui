using RBToolsContextMenu.Application;
using RBToolsContextMenu.Application.Communication.Events;
using RBToolsContextMenu.UI.Wpf.SeedWork;
using System;

namespace RBToolsContextMenu.UI.Wpf.ViewModels
{
    public class CommunicationViewModel : NotifyPropertyChanged
    {
        private string _commandStack;
        private PostCommandIssuer _issuer;

        public string CommandStack
        {
            get => _commandStack;
            set
            {
                if (_commandStack == value) return;
                _commandStack = value;
                OnPropertyChanged();
            }
        }

        private void AppendMessage(object sender, MessageEventArgs args)
        {
            string message = args.Message;
            if (string.IsNullOrWhiteSpace(message))
                return;

            CommandStack += $"{DateTime.Now}: {args.Message}{Environment.NewLine}";
        }

        public PostCommandIssuer Issuer
        {
            get => _issuer;
            set
            {
                if (_issuer == value) return;
                if (_issuer != null) _issuer.MessageReceived -= AppendMessage;

                _issuer = value;
                _issuer.MessageReceived += AppendMessage;
            }
        }
    }
}
