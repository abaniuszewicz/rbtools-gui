using System;

namespace RBToolsContextMenu.Domain.Options
{
    public class Repository : IOption, IHasLongForm, IHasValue
    {
        public string LongForm { get; } = "repository";
        public string Value { get; }
        
        public Repository(string repository)
        {
            Value = repository ?? throw new ArgumentNullException(nameof(repository));
        }
    }
}