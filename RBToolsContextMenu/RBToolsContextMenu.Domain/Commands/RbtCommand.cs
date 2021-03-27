﻿using System.Collections.Generic;
using System.Linq;
using RBToolsContextMenu.Domain.Markers;
using RBToolsContextMenu.Domain.Options;

namespace RBToolsContextMenu.Domain.Commands
{
    public abstract class RbtCommand : IRbtCommand, IPrintable
    {
        public abstract string Command { get; }
        public abstract IEnumerable<IOption> Options { get; }
        
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