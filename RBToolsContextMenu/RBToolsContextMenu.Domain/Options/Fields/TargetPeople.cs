using System;
using System.Collections.Generic;
using System.Linq;

namespace RBToolsContextMenu.Domain.Options.Fields
{
    public class TargetPeople : IOption, IHasLongForm, IHasValue
    {
        public string LongForm { get; } = "target-people";
        public string Value { get; }

        public TargetPeople(IEnumerable<string> targetPeople)
        {
            if (targetPeople is null)
                throw new ArgumentNullException(nameof(targetPeople));
            if (!targetPeople.Any())
                throw new ArgumentException("You must specify at least one target group", nameof(targetPeople));
            
            Value = string.Join(",", targetPeople);
        }
    }
}