using RBToolsContextMenu.UI.Uwp.SeedWork;

namespace RBToolsContextMenu.UI.Uwp.ViewModels
{
    class SendViewModel : NotifyPropertyChanged
    {
        private string _summary;
        private string _description;
        private string _testingDone;

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
    }
}
