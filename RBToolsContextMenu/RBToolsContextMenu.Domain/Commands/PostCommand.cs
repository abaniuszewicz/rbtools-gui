using System.Collections.Generic;
using RBToolsContextMenu.Domain.Options;

namespace RBToolsContextMenu.Domain.Commands
{
    public class PostCommand : RbtCommand
    {
        public override string Command { get; } = "post";
        public override IEnumerable<IOption> Options { get; }

        public PostCommand(IEnumerable<IOption> options)
        {
            Options = options;
        }
    }
}