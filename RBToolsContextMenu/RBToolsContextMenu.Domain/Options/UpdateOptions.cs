namespace RBToolsContextMenu.Domain.Options
{
    public class UpdateOptions : RbtOption
    {
        protected override string Name { get; } = "-update";
        protected override string Shortcut { get; } = "u";

        public UpdateOptions()
        {
        }
    }
}