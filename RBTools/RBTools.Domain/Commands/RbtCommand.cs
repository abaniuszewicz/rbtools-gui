using System.Collections.Generic;
using System.Linq;
using RBTools.Domain.Options;
using RBTools.Domain.SeedWork;

namespace RBTools.Domain.Commands
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