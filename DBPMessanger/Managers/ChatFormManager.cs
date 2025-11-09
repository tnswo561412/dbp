using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ChatForm = DBPMessanger.Forms.ChatForm;

namespace DBPMessanger.Managers
{
    // TODO
    // 앱리 종료 되고 chatForms를 어떻게 저장하지
    public class ChatFormManager
    {
        private Dictionary<long, ChatForm> chatForms = new Dictionary<long, ChatForm>();

        public static ChatFormManager Instance = new ChatFormManager();

        private ChatFormManager() { }

        public ChatForm? serachForm(long targetId)
        {
            return chatForms.GetValueOrDefault(targetId); // 없으면 null 반환
        }

        public void Add(long targetId, ChatForm form)
        {
            chatForms[targetId] = form;
        }

        public void Remove(long targetId)
        {
            chatForms.Remove(targetId);
        }
    }
}
