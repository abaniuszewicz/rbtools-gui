namespace RBToolsContextMenu.Domain.Options.Posting
{
    public class Open : IOption, IHasLongForm, IHasShortForm
    {
        public string LongForm { get; } = "open";
        public string ShortForm { get; } = "o";
    }
}