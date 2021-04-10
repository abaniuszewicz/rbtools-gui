using System.Collections.Generic;
using RBTools.Domain.Options;
using RBTools.Domain.SeedWork;

namespace RBTools.Domain.Commands
{
    public interface IRbtCommand : IPrintable
    {
        public string Command { get; }
        public IEnumerable<IRbtOption> Options { get; }
    }
}