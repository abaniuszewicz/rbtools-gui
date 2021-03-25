using System.Collections.Generic;
using RBToolsContextMenu.Domain.Options;

namespace RBToolsContextMenu.Domain
{
    public class Command
    {
        public IEnumerable<RbtOption> Options { get; }

        public Command(IEnumerable<RbtOption> options)
        {
            Options = options;
        }

        public override string ToString()
        {
            return $"rbt post {string.Join(" ", Options)}";
        }
    }
}