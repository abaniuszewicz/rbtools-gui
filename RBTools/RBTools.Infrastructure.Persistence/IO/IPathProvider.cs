namespace RBTools.Infrastructure.Persistence.IO
{
    public interface IPathProvider
    {
        public string Directory { get; }

        public string GetPathFromKey(string key);
    }
}
