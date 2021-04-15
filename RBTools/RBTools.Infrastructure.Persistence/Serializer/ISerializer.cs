using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBToolsContextMenu.Persistence.Serializer
{
    public interface ISerializer
    {
        public void Serialize<T>(T t);

    }
}
