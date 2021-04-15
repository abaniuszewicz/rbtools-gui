using System.Collections.Generic;
using System.Collections.ObjectModel;
using RBTools.UI.Wpf.Models;

namespace RBTools.UI.Wpf.Utilities
{
    public static class ExtensionMethods
    {
        public static void ReplaceContentWith(this ObservableCollection<SelectableText> original, IEnumerable<SelectableText> replacement)
        {
            original.Clear();
            foreach (var selectableText in replacement)
                original.Add(selectableText.DeepCopy());
        }
    }
}