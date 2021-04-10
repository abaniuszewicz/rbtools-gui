using System;

namespace RBTools.Domain.Options.Post.Fields
{
    public class ChangeDescription : RbtOption, IHasLongForm, IHasShortForm, IHasValue
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