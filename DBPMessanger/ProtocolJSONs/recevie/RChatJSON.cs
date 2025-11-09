using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBPMessanger.JSON.recevie
{
    public class RChatJSON
    {
        public string Type { get; set; }
        public long From { get; set; }
        public string Message { get; set; }

        public RChatJSON() { }
    }
}
