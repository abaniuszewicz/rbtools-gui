using System;

namespace RBToolsContextMenu.Domain.Options.Post
{
    public class Repository : RbtOption, IHasLongForm, IHasValue
    {
        public string LongForm { get; } = "repository";
        public string Value { get; }
        
        public Repository(string repository)
        {
            Value = repository ?? throw new ArgumentNullException(nameof(repository));
        }
    }
}