using System;

namespace RBTools.Domain.Options.Post.Fields
{
    public class Description : RbtOption, IHasLongForm, IHasValue
    {
        public string LongForm { get; } = "description";
        public string Value { get; }

        public Description(string description)
        {
            Value = description ?? throw new ArgumentNullException(nameof(description));
        }
    }
}