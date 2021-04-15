using Newtonsoft.Json;

namespace RBTools.Infrastructure.Persistence.Serialization
{
    public class JsonSerializer : ISerializer
    {
        public string Serialize<T>(T t)
        {
            return JsonConvert.SerializeObject(t);
        }

        public T Deserialize<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
