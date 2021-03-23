using System.Collections.Generic;
using System.Linq;
using RBToolsContextMenu.Domain.Options;

namespace RBToolsContextMenu.Domain
{
    public class Command
    {
        private readonly string _appendix;
        
        public IEnumerable<RbtOption> Options { get; private set; }

        private Command(string appendix, IEnumerable<RbtOption> options)
        {
            _appendix = appendix;
            Options = options;
        }

        public static Command FromPath(string path, IEnumerable<RbtOption> options)
        {
            return FromPath(new[] { path }, options);
        }
        
        public static Command FromPath(IEnumerable<string> path, IEnumerable<RbtOption> options)
        {
            var appendix = string.Join(" ", path.Select(p => $"-I {p}"));
            return new Command(appendix, options);
        }

        public static Command FromRevision(string revision, IEnumerable<RbtOption> options)
        {
            var appendix = revision;
            return new Command(appendix, options);
        }

        public override string ToString()
        {
            return Options.Any()
                ? $"rbt post {string.Join(" ", Options)} {_appendix}"
                : $"rbt post {_appendix}";
        }
    }
}