using System.Windows.Input;
using RBTools.Infrastructure.Persistence.IO;
using RBTools.Infrastructure.Persistence.Serialization;
using RBTools.Infrastructure.Persistence.Exceptions;
using RBTools.UI.Wpf.Models;
using RBTools.UI.Wpf.SeedWork;

namespace RBTools.UI.Wpf.ViewModels
{
    public class SettingsViewModel : NotifyPropertyChanged
    {
        private SettingsMemento _memento;

        public SettingsViewModel(Settings settings, IFileLoader loader, IFileSaver saver, ISerializer serializer)
        {
            Settings = settings;
            _memento = new SettingsMemento(settings);
            
            ImportCommand = new RelayCommand<object>(o => Import(loader, serializer));
            ExportCommand = new RelayCommand<object>(o => Export(saver, serializer));
            SaveCommand = new RelayCommand<object>(o => Save(saver, serializer), o => _memento.HasChanged(Settings));
        }

        public Settings Settings { get; }
        public ICommand ImportCommand { get; }
        public ICommand ExportCommand { get; }
        public ICommand SaveCommand { get; }

        private void Import(IFileLoader fileLoader, ISerializer serializer)
        {
            string content;

            try
            {
                content = fileLoader.Load();
            }
            catch (UserAbortedActionException)
            {
                return;
            }

            var settings = serializer.Deserialize<Settings>(content);
            Settings.RestoreFrom(settings);
        }

        private void Export(IFileSaver saver, ISerializer serializer)
        {
            var memento = new SettingsMemento(Settings);
            var content = serializer.Serialize(memento);
            saver.Save(content);
        }

        private void Save(IFileSaver saver, ISerializer serializer)
        {
            var content = serializer.Serialize(Settings);
            saver.Save("settings", content);
            _memento = new SettingsMemento(Settings);
        }
    }
}
