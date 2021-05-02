namespace RBTools.Infrastructure.Persistence.IO
{
    public interface IFileLoadSave
    {
        public string Load(string filename);
        public string Load();
        public void Save(string filename, string content);
        public void Save(string content);
    }
}
