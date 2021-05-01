using RBTools.Application.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RBTools.UI.Wpf.Utilities
{
    public static class ExtensionMethods
    {
        public static void ReplaceContentWith(this ObservableCollection<AbbreviatedOption> original, IEnumerable<AbbreviatedOption> replacement)
        {
            original.Clear();
            foreach (var selectableText in replacement)
                original.Add(selectableText.DeepCopy());
        }
    }
}