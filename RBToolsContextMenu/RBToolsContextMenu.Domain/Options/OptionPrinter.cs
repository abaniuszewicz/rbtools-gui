using System;

namespace RBToolsContextMenu.Domain.Options
{
    internal class OptionPrinter
    {
        public string Print(IOption option)
        {
            return option switch
            {
                IHasShortForm form and IHasValue value => $"-{form.ShortForm} {value.Value}",
                IHasShortForm form => $"-{form.ShortForm}",
                IHasLongForm form and IHasValue value => $"--{form.LongForm} {value.Value}",
                IHasLongForm form => $"--{form.LongForm}",
                _ => throw new InvalidOperationException("This option is not printable."),
            };
        }
    }
}