namespace RBTools.Domain.Options.Post.Posting
{
    public class Publish : RbtOption, IHasLongForm, IHasShortForm
    {
        public string LongForm { get; } = "publish";
        public string ShortForm { get; } = "p";
    }
}