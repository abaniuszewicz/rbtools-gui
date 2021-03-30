using RBToolsContextMenu.Application.Communication.DTO;
using RBToolsContextMenu.UI.Wpf.SeedWork;
using System;

namespace RBToolsContextMenu.UI.Wpf.Models
{
    public class PostCommandIssuer : NotifyPropertyChanged
    {
        private static readonly Lazy<PostCommandIssuer> _lazyIssuer = new(() => new PostCommandIssuer());
        private readonly Application.PostCommandIssuer _issuer;
        private string _commandStack = string.Empty;

        public static PostCommandIssuer Instance { get => _lazyIssuer.Value; }

        public string CommandStack
        {
            get => _commandStack;
            set
            {
                _commandStack = value;
                OnPropertyChanged();
            }
        }

        private PostCommandIssuer() 
        {
            _issuer = new Application.PostCommandIssuer();
            _issuer.MessageReceived += (s, e) => CommandStack += $"{DateTime.Now.ToLocalTime()}: ⟶ {e.Message}{Environment.NewLine}";
            _issuer.MessageSent += (s, e) => CommandStack += $"{DateTime.Now.ToLocalTime()}: ⟵ {e.Message}{Environment.NewLine}";
        }

        public void Issue(RbtPostDto dto)
        {
            _issuer.Issue(dto);
        }
    }
}
