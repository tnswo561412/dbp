using DBPMessanger.JSON.recevie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ChatForm = DBPMessanger.Forms.ChatForm;

namespace DBPMessanger.Managers
{
    public static class NotifcationManager
    {
        public static void Initialize()
        {
            WebSocketManager.Instance.OnMessageReceived += OnMessageReceived;
        }


        private static void OnMessageReceived(RChatJSON msg)
        {
            ChatForm? form = ChatFormManager.Instance.serachForm(msg.From);

            // 현재 채팅창이 대화창이라면 알람 X
            
                

            // TODO
            // 우측 하단에 알림 창 표시(userControl로 만든후 실행)
            
        }
    }
}
