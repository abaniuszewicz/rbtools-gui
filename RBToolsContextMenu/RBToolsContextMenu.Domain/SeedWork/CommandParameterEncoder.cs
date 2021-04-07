using System.Text.RegularExpressions;

namespace RBToolsContextMenu.Domain.SeedWork
{
    internal static class CommandParameterEncoder
    {
        public static string Encode(string parameter)
        {
            if (string.IsNullOrEmpty(parameter))
                return parameter;

            parameter = BackslashAndQuoteRegex.Replace(parameter, @"$1\$0");
            parameter = LineWithWhitespaceRegex.Replace(parameter, "\"$1$2$2\"");
            return parameter;
        }

        private static readonly Regex BackslashAndQuoteRegex = new Regex(@"(\\*)" + "\"");
        private static readonly Regex LineWithWhitespaceRegex = new Regex(@"^(.*\s.*?)(\\*)$", RegexOptions.Singleline);
    }
}
