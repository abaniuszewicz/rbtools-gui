namespace RBToolsContextMenu.Domain.Options
{
    public abstract class RbtOption
    {
        protected abstract string Name { get; }
        protected virtual string Value { get; }
        protected virtual string Shortcut { get; }

        protected RbtOption()
        {
        }
        
        protected RbtOption(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Shortcut switch
            {
                null when Value is null => $"--{Name}",
                null => $"--{Name} {Value}",
                _ when Value is null => $"-{Shortcut}",
                _ => $"-{Shortcut} {Value}",
            };
        }
    }
}