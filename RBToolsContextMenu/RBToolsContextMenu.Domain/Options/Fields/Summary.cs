using System;

namespace RBToolsContextMenu.Domain.Options.Fields
{
    public class Summary : IOption, IHasLongForm, IHasValue
    {
        public string LongForm { get; } = "summary";
        public string Value { get; }

        public Summary(string summary)
        {
            Value = summary ?? throw new ArgumentNullException(nameof(summary));
        }
    }
}