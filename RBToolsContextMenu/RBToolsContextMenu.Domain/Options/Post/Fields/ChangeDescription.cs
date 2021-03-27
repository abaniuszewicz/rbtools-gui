using System;

namespace RBToolsContextMenu.Domain.Options.Post.Fields
{
    public class ChangeDescription : Option, IHasLongForm, IHasShortForm, IHasValue
    {
        public string LongForm { get; } = "change-description";
        public string ShortForm { get; } = "m";
        public string Value { get; }

        public ChangeDescription(string changeDescription)
        {
            Value = changeDescription ?? throw new ArgumentNullException(nameof(changeDescription));
        }
    }
}