using System;

namespace RBTools.Domain.Options.Post.Fields
{
    public class TestingDoneFile : RbtOption, IHasLongForm, IHasValue
    {
        public string LongForm { get; } = "testing-done-file";

        public string Value { get; }

        public TestingDoneFile(string path)
        {
            Value = path ?? throw new ArgumentNullException(path);
        }
    }
}
