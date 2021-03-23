namespace RBToolsContextMenu.Domain.Options
{
    public class SvnShowCopiesAsAddsOption : RbtOption
    {
        protected override string Name { get; } = "svn-show-copies-as-adds";

        public SvnShowCopiesAsAddsOption(string value) : base(value)
        {
        }
    }
}