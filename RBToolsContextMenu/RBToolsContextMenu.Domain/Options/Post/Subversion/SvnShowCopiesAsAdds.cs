using System;

namespace RBToolsContextMenu.Domain.Options.Post.Subversion
{
    public class SvnShowCopiesAsAdds : Option, IHasLongForm, IHasValue
    {
        public string LongForm { get; } = "svn-show-copies-as-adds";
        public string Value { get; }
        
        public SvnShowCopiesAsAdds(ShowCopiesAsAddsOption showCopiesAsAddsOption)
        {
            Value = showCopiesAsAddsOption switch
            {
                ShowCopiesAsAddsOption.Yes => "y",
                ShowCopiesAsAddsOption.No => "n",
                _ => throw new ArgumentOutOfRangeException(nameof(showCopiesAsAddsOption)),
            };
        }
    }
    
    public enum ShowCopiesAsAddsOption
    {
        Yes,
        No,
    }
}