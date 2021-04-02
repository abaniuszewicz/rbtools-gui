using Newtonsoft.Json;
using System.IO;

namespace RBToolsContextMenu.Persistence.IO
{
    internal class JsonFileSerializer : IFileSerializer
    {
        public void Serialize<T>(T t, string path)
        {
            string json = JsonConvert.SerializeObject(t);
            File.WriteAllText(path, json);
        }

        public T Deserialize<T>(string path)
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
