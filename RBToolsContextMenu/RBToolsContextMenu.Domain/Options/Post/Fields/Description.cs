using System;

namespace RBToolsContextMenu.Domain.Options.Post.Fields
{
    public class Description : Option, IHasLongForm, IHasValue
    {
        public string LongForm { get; } = "description";
        public string Value { get; }

        public Description(string description)
        {
            Value = description ?? throw new ArgumentNullException(nameof(description));
        }
    }
}