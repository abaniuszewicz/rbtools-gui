using System.Collections.Generic;
using System.Linq;
using RBToolsContextMenu.Domain.Options;
using RBToolsContextMenu.Domain.SeedWork;

namespace RBToolsContextMenu.Domain.Commands
{
    public abstract class RbtCommand : IRbtCommand
    {
        public abstract string Command { get; }
        public abstract IEnumerable<IRbtOption> Options { get; }
        
        public string Print()
        {
            var options = Options.OfType<IPrintable>()
                .Select(po => po.Print());
            
            return options.Any()
                ? $"rbt {Command} {string.Join(" ", options)}"
                : $"rbt {Command}";
        }
    }
}