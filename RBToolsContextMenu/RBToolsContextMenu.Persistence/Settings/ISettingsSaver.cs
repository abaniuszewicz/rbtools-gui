namespace RBToolsContextMenu.Persistence.Settings
{
    public interface ISettingsSaver
    {
        public void Save<T>(T t, string key);
    }
}
