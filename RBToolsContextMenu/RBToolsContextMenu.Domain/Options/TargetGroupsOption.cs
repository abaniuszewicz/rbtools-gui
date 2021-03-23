namespace RBToolsContextMenu.Domain.Options
{
    public class TargetGroupsOption : RbtOption
    {
        protected override string Name { get; } = "target-groups";

        public TargetGroupsOption(string value) : base(value)
        {
        }
    }
}