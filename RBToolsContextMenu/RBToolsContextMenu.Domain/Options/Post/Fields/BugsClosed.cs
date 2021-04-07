using System;
using System.Collections.Generic;
using System.Linq;

namespace RBToolsContextMenu.Domain.Options.Post.Fields
{
    public class BugsClosed : RbtOption, IHasLongForm, IHasValue
    {
        public string LongForm { get; } = "--bugs-closed";
        public string Value { get; }

        public BugsClosed(IEnumerable<string> bugIds)
        {
            if (bugIds is null)
                throw new ArgumentNullException(nameof(bugIds));
            if (!bugIds.Any())
                throw new ArgumentException("You must specify at least one bug id", nameof(bugIds));
            
            Value = string.Join(",", bugIds);
        }
    }
}