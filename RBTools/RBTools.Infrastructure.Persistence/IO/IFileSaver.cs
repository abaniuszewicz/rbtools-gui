namespace RBTools.Infrastructure.Persistence.IO
{
    public interface IFileSaver
    {
        public void Save(string key, string content);
        public void Save(string content);
    }
}
