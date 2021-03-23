namespace RBToolsContextMenu.Domain.Options
{
    public class ReviewRequestIdOption : RbtOption
    {
        protected override string Name { get; } = "review-request-id";
        protected override string Shortcut { get; } = "r";
        
        public ReviewRequestIdOption(string value) : base(value)
        {
        }
    }
}