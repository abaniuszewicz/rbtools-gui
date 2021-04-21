using System;

namespace RBTools.Domain.Options.Post.DiffGeneration
{
    public class Revision : RbtOption, IHasValue
    {
        public string Value { get; }

        public Revision(string revision)
        {
            Value = revision ?? throw new ArgumentNullException(nameof(revision));
        }
    }
}
