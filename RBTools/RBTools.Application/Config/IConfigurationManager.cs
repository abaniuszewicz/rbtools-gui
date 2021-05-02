namespace RBTools.Application.Config
{
    public interface IConfigurationManager
    {
        public IConfiguration Load();
        public void Save(IConfiguration settings);
        public IConfiguration Import();
        public void Export(IConfiguration settings);
    }
}
