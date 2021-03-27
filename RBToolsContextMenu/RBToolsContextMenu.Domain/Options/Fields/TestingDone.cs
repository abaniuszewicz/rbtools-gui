using System;

namespace RBToolsContextMenu.Domain.Options.Fields
{
    public class TestingDone : IOption, IHasLongForm, IHasValue
    {
        public string LongForm { get; } = "testing-done";
        public string Value { get; }

        public TestingDone(string testingDone)
        {
            Value = testingDone ?? throw new ArgumentNullException(nameof(testingDone));
        }
    }
}