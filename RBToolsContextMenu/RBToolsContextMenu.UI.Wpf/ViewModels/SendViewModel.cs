using RBToolsContextMenu.UI.Wpf.SeedWork;
using RBToolsContextMenu.UI.Wpf.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using RBToolsContextMenu.Application.Communication.DTO;
using RBToolsContextMenu.Application;
using RBToolsContextMenu.UI.Wpf.SeedWork.Mapping;

namespace RBToolsContextMenu.UI.Wpf.ViewModels
{
    public class SendViewModel : NotifyPropertyChanged
    {
        private string _summary;
        private string _description;
        private string _testingDone;
        private string _reviewId;
        private string _updateDescription;
        private string _root;
        private string _repository;
        private string _server;
        private ReviewType _reviewType;
        private bool _openInBrowser;
        private bool _publish;
        private bool _svnShowCopiesAsAdds;
        
        public string Summary
        {
            get => _summary;
            set
            {
                if (_summary == value) return;
                _summary = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (_description == value) return;
                _description = value;
                OnPropertyChanged();
            }
        }

        public string TestingDone
        {
            get => _testingDone;
            set
            {
                if (_testingDone == value) return;
                _testingDone = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<SelectableText> Groups { get; set; } = new();

        public ObservableCollection<SelectableText> People { get; set; } = new();

        public ReviewType ReviewType
        {
            get => _reviewType;
            set
            {
                if (_reviewType == value) return;
                _reviewType = value;
                OnPropertyChanged();
            }
        }

        public string ReviewId
        {
            get => _reviewId;
            set
            {
                var actualValue = string.Concat(value.Where(c => c >= '0' && c <= '9'));
                if (_reviewId == actualValue) return;
                _reviewId = actualValue;
                OnPropertyChanged();
            }
        }

        public string UpdateDescription
        {
            get => _updateDescription;
            set
            {
                if (_updateDescription == value) return;
                _updateDescription = value;
                OnPropertyChanged();
            }
        }

        public string Root
        {
            get => _root;
            set
            {
                if (_root == value) return;
                _root = value;
                OnPropertyChanged();
            }
        }

        public string Repository
        {
            get => _repository;
            set
            {
                if (_repository == value) return;
                _repository = value;
                OnPropertyChanged();
            }
        }

        public string Server
        {
            get => _server;
            set
            {
                if (_server == value) return;
                _server = value;
                OnPropertyChanged();
            }
        }

        public bool OpenInBrowser
        {
            get => _openInBrowser;
            set
            {
                if (_openInBrowser == value) return;
                _openInBrowser = value;
                OnPropertyChanged();
            }
        }

        public bool Publish
        {
            get => _publish;
            set
            {
                if (_publish == value) return;
                _publish = value;
                OnPropertyChanged();
            }
        }

        public bool SvnShowCopiesAsAdds
        {
            get => _svnShowCopiesAsAdds;
            set
            {
                if (_svnShowCopiesAsAdds == value) return;
                _svnShowCopiesAsAdds = value;
                OnPropertyChanged();
            }
        }

        public PostCommandIssuer Issuer { get; set; }

        public ICommand PostCommand => new RelayCommand<RbtPostDto>(o => Issuer.Issue(Mapper.CreateDto(this)));
    }
}
