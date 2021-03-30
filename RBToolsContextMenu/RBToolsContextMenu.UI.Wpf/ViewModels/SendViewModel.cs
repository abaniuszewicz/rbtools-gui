using RBToolsContextMenu.UI.Wpf.SeedWork;
using RBToolsContextMenu.UI.Wpf.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using RBToolsContextMenu.Application.Communication.DTO;

namespace RBToolsContextMenu.UI.Wpf.ViewModels
{
    public class SendViewModel : NotifyPropertyChanged
    {
        private string _summary;
        private string _description;
        private string _testingDone;
        private string _reviewId;
        private string _updateDescription;
        private string _repository;
        private string _server;
        private ReviewType _reviewType;
        private bool _openInBrowser;
        private bool _publish;
        private bool _svnShowCopiesAsAdds;

        public SendViewModel()
        {
            Groups.Add(new SelectableText("Developers"));
            Groups.Add(new SelectableText("Testers"));

            People.Add(new SelectableText("John", true));
            People.Add(new SelectableText("Paul"));
        }

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

        public ObservableCollection<SelectableText> Groups { get; } = new ObservableCollection<SelectableText>();

        public ObservableCollection<SelectableText> People { get; } = new ObservableCollection<SelectableText>();

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

        public PostCommandIssuer Issuer { get; set; } = PostCommandIssuer.Instance;

        public ICommand PostCommand => new RelayCommand<RbtPostDto>(o => Issuer.Issue(CreateDto()));

        private RbtPostDto CreateDto()
        {
            var dto = new RbtPostDto()
            {
                OpenBrowser = OpenInBrowser,
                Publish = Publish,
                SvnShowCopiesAsAdds = SvnShowCopiesAsAdds,
            };

            if (!string.IsNullOrWhiteSpace(Description))
                dto.Description = Description;
            if (!string.IsNullOrWhiteSpace(Summary))
                dto.Summary = Summary;
            if (!string.IsNullOrWhiteSpace(TestingDone))
                dto.TestingDone = TestingDone;
            if (!string.IsNullOrWhiteSpace(Repository))
                dto.Repository = Repository;
            if (!string.IsNullOrWhiteSpace(Server))
                dto.Server = Server;

            dto.TargetGroups = Groups.Where(g => g.IsSelected).Select(g => g.Text);
            dto.TargetPeople = Groups.Where(p => p.IsSelected).Select(p => p.Text);

            if (ReviewType == ReviewType.Update)
            {
                dto.Update = true;
                if (!string.IsNullOrWhiteSpace(UpdateDescription))
                    dto.UpdateDescription = UpdateDescription;
                if (!string.IsNullOrWhiteSpace(ReviewId) && int.TryParse(ReviewId, out int reviewId))
                    dto.ReviewRequestId = reviewId;
            }

            return dto;
        }
    }
}
