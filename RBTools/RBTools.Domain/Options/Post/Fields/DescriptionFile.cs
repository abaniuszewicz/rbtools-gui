using System;

namespace RBTools.Domain.Options.Post.Fields
{
    public class DescriptionFile : RbtOption, IHasLongForm, IHasValue
    {
        public string LongForm { get; } = "description-file";

        public string Value { get; }

        public DescriptionFile(string path)
        {
            Value = path ?? throw new ArgumentNullException(path);
        }
    }
}
