using RBTools.Domain.Options;

namespace RBTools.Domain.Tests.Options
{
    public abstract class OptionWithLongFormAndShortFormAndValue : RbtOption, IHasLongForm, IHasShortForm, IHasValue
    {
        public abstract string LongForm { get; }
        public abstract string ShortForm { get; }
        public abstract string Value { get; }
    }

    public abstract class OptionWithLongFormAndShortForm : RbtOption, IHasLongForm, IHasShortForm
    {
        public abstract string ShortForm { get; }
        public abstract string LongForm { get; }
    }

    public abstract class OptionWithLongFormAndValue : RbtOption, IHasLongForm, IHasValue
    {
        public abstract string LongForm { get; }
        public abstract string Value { get; }
    }

    public abstract class OptionWithShortFormAndValue : RbtOption, IHasShortForm, IHasValue
    {
        public abstract string ShortForm { get; }
        public abstract string Value { get; }
    }

    public abstract class OptionWithLongForm : RbtOption, IHasLongForm
    {
        public abstract string LongForm { get; }
    }

    public abstract class OptionWithShortForm : RbtOption, IHasShortForm
    {
        public abstract string ShortForm { get; }
    }

    public abstract class OptionWithValue : RbtOption, IHasValue
    {
        public abstract string Value { get; }
    }
}
