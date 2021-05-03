using System.Linq;
using System.Windows.Input;
using RBTools.Application.Commands;
using RBTools.Application.Communication.DTO;
using RBTools.Application.Communication.Mapping;
using RBTools.Application.Models;
using RBTools.UI.Wpf.SeedWork;

namespace RBTools.UI.Wpf.ViewModels
{
    public class SendViewModel : NotifyPropertyChanged
    {
        private string _summary;
        private string _description;
        private string _testingDone;
        private string _reviewId;
        private string _updateDescription;
        private ReviewType _reviewType;
        private string _revision;
        private string _bugIds;

        public SendViewModel(ConfigurationViewModel configuration, PostCommandIssuer issuer, IMapper<SendViewModel, RbtPostDto> mapper)
        {
            Configuration = configuration;
            Issuer = issuer;
            ReviewType = ReviewTypes.First();
            Mapper = mapper;
        }

        public ConfigurationViewModel Configuration { get; }
        public PostCommandIssuer Issuer { get; }
        public IMapper<SendViewModel, RbtPostDto> Mapper { get; }
        public ReviewType[] ReviewTypes { get; } = new[] { ReviewType.PreCommitNew, ReviewType.PreCommitUpdate, ReviewType.PostCommitNew, ReviewType.PostCommitUpdate };
        public ICommand PostCommand => new RelayCommand<RbtPostDto>(o => Issuer.Issue(Mapper.Map(this)));


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

        public string Revision
        {
            get => _revision;
            set
            {
                if (_revision == value) return;
                _revision = value;
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

        public string BugIds
        {
            get => _bugIds;
            set
            {
                if (_bugIds == value) return;
                _bugIds = value;
                OnPropertyChanged();
            }
        }
    }
}
