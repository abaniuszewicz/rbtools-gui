using System;
using RBTools.Application.Commands;
using RBTools.Application.Communication.Events;
using RBTools.UI.Wpf.SeedWork;

namespace RBTools.UI.Wpf.ViewModels
{
    public class CommunicationViewModel : NotifyPropertyChanged
    {
        private PostCommandIssuer _issuer;
        private string _commandStack;

        public CommunicationViewModel(PostCommandIssuer issuer)
        {
            Issuer = issuer;
        }

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
            var message = args.Message;
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
