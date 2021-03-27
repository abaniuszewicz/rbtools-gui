namespace RBToolsContextMenu.Domain.Options.Post.Posting
{
    public class Publish : Option, IHasLongForm, IHasShortForm
    {
        public string LongForm { get; } = "publish";
        public string ShortForm { get; } = "p";
    }
}