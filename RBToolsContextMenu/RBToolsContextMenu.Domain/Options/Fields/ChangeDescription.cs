using System;

namespace RBToolsContextMenu.Domain.Options.Fields
{
    public class ChangeDescription : IOption, IHasLongForm, IHasShortForm, IHasValue
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