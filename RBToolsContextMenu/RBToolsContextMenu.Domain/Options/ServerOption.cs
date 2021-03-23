namespace RBToolsContextMenu.Domain.Options
{
    public class ServerOption : RbtOption
    {
        protected override string Name { get; } = "server";

        public ServerOption(string value) : base(value)
        {
        }
    }
}