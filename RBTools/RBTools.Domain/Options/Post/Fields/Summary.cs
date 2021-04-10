using System;

namespace RBTools.Domain.Options.Post.Fields
{
    public class Summary : RbtOption, IHasLongForm, IHasValue
    {
        public string LongForm { get; } = "summary";
        public string Value { get; }

        public Summary(string summary)
        {
            Value = summary ?? throw new ArgumentNullException(nameof(summary));
        }
    }
}