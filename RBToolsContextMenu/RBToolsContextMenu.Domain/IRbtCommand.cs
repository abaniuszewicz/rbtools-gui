using System.Collections.Generic;
using RBToolsContextMenu.Domain.Options;

namespace RBToolsContextMenu.Domain
{
    public interface IRbtCommand
    {
        public IEnumerable<IOption> Options { get; }

        public string Print();
    }
}