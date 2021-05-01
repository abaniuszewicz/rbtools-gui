namespace RBTools.Application.Configuration
{
    public interface ISettingsManager
    {
        public ISettings Load();
        public void Save(ISettings settings);
        public ISettings Import();
        public void Export(ISettings settings);
    }
}
