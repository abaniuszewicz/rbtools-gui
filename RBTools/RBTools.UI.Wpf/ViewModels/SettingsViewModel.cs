using System.Windows.Input;
using RBTools.Application.Configuration;
using RBTools.Application.Exceptions;
using RBTools.UI.Wpf.SeedWork;

namespace RBTools.UI.Wpf.ViewModels
{
    public class SettingsViewModel : NotifyPropertyChanged
    {
        private ISettingsMemento _memento;
        private readonly ISettingsManager _settingsManager;

        public SettingsViewModel(ISettings settings, ISettingsManager settingsManager)
        {
            Settings = settings;
            _settingsManager = settingsManager;
            _memento = new SettingsMemento(settings);
            
            ImportCommand = new RelayCommand<object>(o => Import());
            ExportCommand = new RelayCommand<object>(o => Export());
            SaveCommand = new RelayCommand<object>(o => Save(), o => _memento.HasStateChanged(Settings));
        }

        public ISettings Settings { get; }
        public ICommand ImportCommand { get; }
        public ICommand ExportCommand { get; }
        public ICommand SaveCommand { get; }

        private void Import()
        {
            try
            {
                ISettings settings = _settingsManager.Import();
                Settings.RestoreFrom(settings);
            }
            catch (UserAbortedActionException)
            {
                return;
            }
        }

        private void Export()
        {
            _settingsManager.Export(Settings);
        }

        private void Save()
        {
            _settingsManager.Save(Settings);
        }
    }
}
