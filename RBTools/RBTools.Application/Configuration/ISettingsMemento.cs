namespace RBTools.Application.Configuration
{
    public interface ISettingsMemento : ISettings
    {
        public bool HasStateChanged(ISettings current);
    }
}
