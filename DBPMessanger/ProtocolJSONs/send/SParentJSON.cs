using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBPMessanger.MessageProtocol.send
{
    internal abstract class SParentJSON
    {
        public string Type { get; set; }

        public SParentJSON(string type)
        {
            Type = type;
        }

        public abstract string SerializeJSON();
    }
}
