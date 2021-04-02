namespace RBToolsContextMenu.Persistence.Settings
{
    public interface ISettingsLoader
    {
        public T Load<T>(string key);
    }
}
