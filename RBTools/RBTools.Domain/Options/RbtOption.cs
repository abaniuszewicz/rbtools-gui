using System;
using System.Text.RegularExpressions;
using RBTools.Domain.SeedWork;

namespace RBTools.Domain.Options
{
    public abstract class RbtOption : IRbtOption
    {
        public string Print()
        {
            return this switch
            {
                IHasShortForm form and IHasValue value => $"-{form.ShortForm} {Encode(value.Value)}",
                IHasShortForm form => $"-{form.ShortForm}",
                IHasLongForm form and IHasValue value => $"--{form.LongForm} {Encode(value.Value)}",
                IHasLongForm form => $"--{form.LongForm}",
                IHasValue value => $"{Encode(value.Value)}",
                _ => throw new NotImplementedException("This option does not implement any members that could be used for printing."), // HACK: not really proud of this
            };
        }

        private static string Encode(string parameter)
        {
            if (string.IsNullOrEmpty(parameter))
                return parameter;

            parameter = BackslashAndQuoteRegex.Replace(parameter, @"$1\$0");
            parameter = LineWithWhitespaceRegex.Replace(parameter, "\"$1$2$2\"");
            return parameter;
        }

        private static readonly Regex BackslashAndQuoteRegex = new(@"(\\*)" + "\"");
        private static readonly Regex LineWithWhitespaceRegex = new(@"^(.*\s.*?)(\\*)$", RegexOptions.Singleline);
    }
}