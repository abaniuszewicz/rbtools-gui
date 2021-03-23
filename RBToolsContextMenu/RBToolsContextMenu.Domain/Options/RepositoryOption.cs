namespace RBToolsContextMenu.Domain.Options
{
    public class RepositoryOption : RbtOption
    {
        protected override string Name { get; } = "repository";
        
        public RepositoryOption(string value) : base(value)
        {
        }
    }
}