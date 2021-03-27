using System;
using System.Collections.Generic;
using System.Linq;

namespace RBToolsContextMenu.Domain.Options.Post.Fields
{
    public class TargetGroups : Option, IHasLongForm, IHasValue
    {
        public string LongForm { get; } = "target-groups";
        public string Value { get; }

        public TargetGroups(IEnumerable<string> targetGroups)
        {
            if (targetGroups is null)
                throw new ArgumentNullException(nameof(targetGroups));
            if (!targetGroups.Any())
                throw new ArgumentException("You must specify at least one target group", nameof(targetGroups));
            
            Value = string.Join(",", targetGroups);
        }
    }
}