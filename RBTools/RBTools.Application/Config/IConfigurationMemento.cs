namespace RBTools.Application.Config
{
    public interface IConfigurationMemento : IConfiguration
    {
        public bool HasStateChanged(IConfiguration current);
    }
}
