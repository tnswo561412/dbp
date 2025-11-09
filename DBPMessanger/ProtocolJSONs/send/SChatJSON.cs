using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DBPMessanger.MessageProtocol.send
{
    internal class SChatJSON : SParentJSON
    {
        public long To { get; set; }
        public string Message { get; set; }

        public SChatJSON(string type, long to, string message) : base(type)
        {
            To = to;
            Message = message;
        }
        public override string SerializeJSON()
        {
            var msg = new { type = Type, to = To, message = Message};
            return JsonSerializer.Serialize(msg);
        }
    }
}
