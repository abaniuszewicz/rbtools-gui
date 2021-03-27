namespace RBToolsContextMenu.Domain.Options.Posting
{
    public class Update : IOption, IHasLongForm, IHasShortForm
    {
        public string LongForm { get; } = "-update";
        public string ShortForm { get; } = "u";
    }
}