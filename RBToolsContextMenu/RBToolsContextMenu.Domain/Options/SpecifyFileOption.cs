namespace RBToolsContextMenu.Domain.Options
{
    public class SpecifyFileOption : RbtOption
    {
        protected override string Name { get; } = "include";
        protected override string Shortcut { get; } = "I";

        public SpecifyFileOption(string value) : base(value)
        {
        }
    }
}
