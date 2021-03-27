using System;

namespace RBToolsContextMenu.Domain.Options.Fields
{
    public class Description : IOption, IHasLongForm, IHasValue
    {
        public string LongForm { get; } = "description";
        public string Value { get; }

        public Description(string description)
        {
            Value = description ?? throw new ArgumentNullException(nameof(description));
        }
    }
}