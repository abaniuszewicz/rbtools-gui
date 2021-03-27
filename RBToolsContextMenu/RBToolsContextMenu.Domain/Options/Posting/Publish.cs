namespace RBToolsContextMenu.Domain.Options.Posting
{
    public class Publish : IOption, IHasLongForm, IHasShortForm
    {
        public string LongForm { get; } = "publish";
        public string ShortForm { get; } = "p";
    }
}