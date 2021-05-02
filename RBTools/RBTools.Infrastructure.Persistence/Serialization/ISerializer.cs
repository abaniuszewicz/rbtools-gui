namespace RBTools.Infrastructure.Persistence.Serialization
{
    public interface ISerializer
    {
        public T Deserialize<T>(string content);
        public string Serialize<T>(T t);
    }
}