﻿using System.Collections.Generic;
using System.Linq;
using RBTools.UI.Wpf.Models;
using RBTools.UI.Wpf.ViewModels;

namespace RBTools.UI.Wpf.Utilities.Settings
{
    public class SettingsMemento
    {
        public IEnumerable<SelectableText> Groups { get; init; } = Enumerable.Empty<SelectableText>();
        public IEnumerable<SelectableText> People { get; init; } = Enumerable.Empty<SelectableText>();
        public string RepositoryRoot { get; init; }
        public string RepositoryUrl { get; init; }
        public string RepositoryName { get; init; }
        public bool OpenInBrowser { get; init; }
        public bool Publish { get; init; }
        public bool SvnShowCopiesAsAdds { get; init; }

        public SettingsMemento()
        {
        }

        public SettingsMemento(SettingsViewModel settings)
        {
            Groups = settings.Groups.Select(g => g.DeepCopy()).ToList();
            People = settings.People.Select(p => p.DeepCopy()).ToList();
            RepositoryRoot = settings.RepositoryRoot;
            RepositoryUrl = settings.RepositoryUrl;
            RepositoryName = settings.RepositoryName;
            OpenInBrowser = settings.OpenInBrowser;
            Publish = settings.Publish;
            SvnShowCopiesAsAdds = settings.SvnShowCopiesAsAdds;
        }

        public void RestoreTo(SettingsViewModel settings)
        {
            ReplaceContent(settings.Groups, Groups);
            ReplaceContent(settings.People, People);
            settings.RepositoryRoot = RepositoryRoot;
            settings.RepositoryUrl = RepositoryUrl;
            settings.RepositoryName = RepositoryName;
            settings.OpenInBrowser = OpenInBrowser;
            settings.Publish = Publish;
            settings.SvnShowCopiesAsAdds = SvnShowCopiesAsAdds;
        }

        public void RestoreTo(SendViewModel send)
        {
            ReplaceContent(send.Groups, Groups);
            ReplaceContent(send.People, People);
            send.Root = RepositoryRoot;
            send.Server = RepositoryUrl;
            send.Repository = RepositoryName;
            send.OpenInBrowser = OpenInBrowser;
            send.Publish = Publish;
            send.SvnShowCopiesAsAdds = SvnShowCopiesAsAdds;
        }

        public bool HasChanged(SettingsViewModel settings)
        {
            var equals = Groups.SequenceEqual(settings.Groups)
                         && People.SequenceEqual(settings.People)
                         && (RepositoryRoot ?? string.Empty) == (settings.RepositoryRoot ?? string.Empty)
                         && (RepositoryUrl ?? string.Empty) == (settings.RepositoryUrl ?? string.Empty)
                         && (RepositoryName ?? string.Empty) == (settings.RepositoryName ?? string.Empty)
                         && OpenInBrowser == settings.OpenInBrowser
                         && Publish == settings.Publish
                         && SvnShowCopiesAsAdds == settings.SvnShowCopiesAsAdds;

            return !equals;
        }

        private static void ReplaceContent(ICollection<SelectableText> collection, IEnumerable<SelectableText> replacement)
        {
            collection.Clear();
            foreach (var selectableText in replacement)
                collection.Add(selectableText.DeepCopy());
        }
    }
}