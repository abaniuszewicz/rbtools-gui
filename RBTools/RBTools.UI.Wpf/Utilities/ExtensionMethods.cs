using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RBTools.UI.Wpf.Utilities
{
    public static class ExtensionMethods
    {
        public static void ReplaceContentWith<T>(this ObservableCollection<T> original, IEnumerable<T> replacements)
        {
            original.Clear();
            foreach (var replacement in replacements)
                original.Add(replacement);
        }
    }
}