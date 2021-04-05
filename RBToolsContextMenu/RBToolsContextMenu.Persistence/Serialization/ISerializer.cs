namespace RBToolsContextMenu.Persistence.Serialization
{
    public interface ISerializer
    {
        public T Deserialize<T>(string path);
        public string Serialize<T>(T t);
    }
}