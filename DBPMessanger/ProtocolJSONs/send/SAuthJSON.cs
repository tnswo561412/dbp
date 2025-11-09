using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DBPMessanger.MessageProtocol.send
{
    internal class SAuthJSON : SParentJSON
    {
        public long UserId { get; set; }

        public SAuthJSON(string type, long userId) : base(type)
        {
            Type = type;
            UserId = userId;
        }
        public override string SerializeJSON()
        {
            var msg = new { type = Type, userId = UserId };
            return JsonSerializer.Serialize(msg);
        }
    }
}
