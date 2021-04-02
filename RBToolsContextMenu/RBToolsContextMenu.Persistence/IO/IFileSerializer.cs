namespace RBToolsContextMenu.Persistence.IO
{
    public interface IFileSerializer
    {
        public T Deserialize<T>(string path);
        public void Serialize<T>(T t, string path);
    }
}