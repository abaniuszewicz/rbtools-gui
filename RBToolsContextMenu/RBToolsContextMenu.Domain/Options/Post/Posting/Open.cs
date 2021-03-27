namespace RBToolsContextMenu.Domain.Options.Post.Posting
{
    public class Open : RbtOption, IHasLongForm, IHasShortForm
    {
        public string LongForm { get; } = "open";
        public string ShortForm { get; } = "o";
    }
}