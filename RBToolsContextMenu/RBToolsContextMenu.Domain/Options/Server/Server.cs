using System;

namespace RBToolsContextMenu.Domain.Options.Server
{
    public class Server : IOption, IHasLongForm, IHasValue
    {
        public string LongForm { get; } = "server";
        public string Value { get; }
        
        public Server(string server)
        {
            Value = server ?? throw new ArgumentNullException(nameof(server));
        }
    }
}