using RBToolsContextMenu.UI.Uwp.Models;
using RBToolsContextMenu.UI.Uwp.SeedWork;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace RBToolsContextMenu.UI.Uwp.ViewModels
{
    class SendViewModel : NotifyPropertyChanged
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
            Groups.Add("Developers");
            Groups.Add("Testers");

            People.Add("John");
            People.Add("Paul");
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

        public ObservableCollection<string> Groups { get; } = new ObservableCollection<string>();

        public ObservableCollection<string> People { get; } = new ObservableCollection<string>();

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

        public ICommand PostCommand { get; } = new RelayCommand<object>(o => throw new NotImplementedException());
    }
}
