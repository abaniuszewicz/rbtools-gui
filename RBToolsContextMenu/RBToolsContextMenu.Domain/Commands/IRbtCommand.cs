using System.Collections.Generic;
using RBToolsContextMenu.Domain.Options;

namespace RBToolsContextMenu.Domain.Commands
{
    public interface IRbtCommand
    {
        public string Command { get; }
        public IEnumerable<IOption> Options { get; }
    }
}