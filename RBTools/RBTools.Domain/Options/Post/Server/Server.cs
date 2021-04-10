using System;

namespace RBTools.Domain.Options.Post.Server
{
    public class Server : RbtOption, IHasLongForm, IHasValue
    {
        public string LongForm { get; } = "server";
        public string Value { get; }
        
        public Server(string server)
        {
            Value = server ?? throw new ArgumentNullException(nameof(server));
        }
    }
}