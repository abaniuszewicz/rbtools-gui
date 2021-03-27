using System.Collections.Generic;
using System.Linq;
using System.Text;
using RBToolsContextMenu.Domain.Options;

namespace RBToolsContextMenu.Domain
{
    public class RbtCommand : IRbtCommand
    {
        public IEnumerable<IOption> Options { get; }

        public RbtCommand(IEnumerable<IOption> options)
        {
            Options = options;
        }

        public string Print()
        {
            var optionPrinter = new OptionPrinter();
            return $"rbt post {string.Join(" ", Options.Select(optionPrinter.Print))}";
        }
    }
}