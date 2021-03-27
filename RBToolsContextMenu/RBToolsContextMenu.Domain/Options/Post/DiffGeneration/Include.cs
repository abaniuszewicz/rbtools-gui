using System;

namespace RBToolsContextMenu.Domain.Options.Post.DiffGeneration
{
    public class Include : RbtOption, IHasLongForm, IHasShortForm, IHasValue
    {
        public string LongForm { get; } = "include";
        public string ShortForm { get; } = "I";
        public string Value { get; }

        public Include(string include)
        {
            Value = include ?? throw new ArgumentNullException(nameof(include));
        }
    }
}
