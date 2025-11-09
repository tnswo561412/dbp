using DBPMessanger.infos;
using DBPMessanger.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBPMessanger.Items
{
    public class ChatItem
    {
        public UserInfo target { get; set; }
        public ChatLogInfo chatLog { get; set; }

        public ChatItem(UserInfo target, ChatLogInfo chatLog)
        {
            this.target = target;
            this.chatLog = chatLog;
        }
    }
}
