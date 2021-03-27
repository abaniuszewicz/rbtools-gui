using System.Collections.Generic;
using RBToolsContextMenu.Domain.Options;
using RBToolsContextMenu.Domain.SeedWork;

namespace RBToolsContextMenu.Domain.Commands
{
    public interface IRbtCommand : IPrintable
    {
        public string Command { get; }
        public IEnumerable<IRbtOption> Options { get; }
    }
}