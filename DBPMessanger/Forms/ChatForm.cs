using DBPMessanger.Controls;
using DBPMessanger.infos;
using DBPMessanger.Item;
using DBPMessanger.JSON.recevie;
using DBPMessanger.Managers;
using DBPMessanger.MessageProtocol.send;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace DBPMessanger.Forms
{
    public partial class ChatForm : Form
    {
        private UserInfo? target;
        public ChatForm(long targetId)
        {
            // 매니저를 통해서 구독해서 메세지를 받으면 할당받은 함수로 처리한다.
            WebSocketManager.Instance.OnMessageReceived += OnMessageReceived;

            // 이전 폼에서 선택된 user_id를 통해서 상대방의 정보를 가져온다
            target = DBManager.Instance.Query<UserInfo>(
                q => q.Include(u => u.Department)
                .Where(u => u.Id == targetId))
                ?.FirstOrDefault() ?? null;

            if (target == null)
                return;

            InitializeComponent();

            // 이전에 나눈 대화 로드
            loadChat();
            labelName.Text = target.Name;
            labelDepartment.Text = target.Department.Name;
        }

        private void loadChat()
        {
            if (target == null)
                return;

            // 채팅창이 켜지면 ChatLog를 보고 이전대화를 로드시킨다.
            List<ChatLogInfo> ownerUser = DBManager.Instance.Query<ChatLogInfo>(
                q => q.Include(u => u.Sender)
                .Include(u => u.Target)
                .Where(u => u.SenderUserId == OwnerUserManager.Instance.userInfo.Id
                && u.TargetUserId == target.Id)) ?? new List<ChatLogInfo>();

            List<ChatLogInfo> targetUser = DBManager.Instance.Query<ChatLogInfo>(
                q => q.Include(u => u.Sender)
                .Include(u => u.Target)
                .Where(u => u.SenderUserId == target.Id
                && u.TargetUserId == OwnerUserManager.Instance.userInfo.Id)) ?? new List<ChatLogInfo>();

            if (ownerUser == null || targetUser == null)
                return;

            var allChats = ownerUser.Concat(targetUser)
                .OrderBy(c => c.MessageTime).ToList();

            foreach (var chat in allChats)
            {
                if (chat.SenderUserId == target.Id)
                {
                    AddMessage(chat.Message, chat.MessageTime, false);
                }
                else
                {
                    AddMessage(chat.Message, chat.MessageTime, true);
                }
            }
        }

        private void ChatForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 채팅 폼을 끄면 매니저에서 채팅창을 제거시킨다.

            if (target == null)
                return;
            ChatFormManager.Instance.Remove(target.Id);
        }

        void AddMessage(string message, DateTime dateTime, bool isMine)
        {
            if (target == null)
                return;

            string name = "";
            Image image = null;

            if (!isMine)
            {
                name = target.Name;
                //image = target.ProfileImage;
            }

            ChatControl chat = new ChatControl(name, message, dateTime, isMine, image, panelChat.Width);

            chat.Parent = panelChat; 
            panelChat.Controls.SetChildIndex(chat, 0);
        }


        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (target == null)
                return;

            string message = richTextBoxChat.Text.Trim();
            richTextBoxChat.Text = "";

            if (string.IsNullOrEmpty(message))
                return;

            AddMessage(message, DateTime.Now, true);

            // DB에 메세지 내역 추가
            DBManager.Instance.Insert(
                new ChatLogInfo
                {
                    SenderUserId = OwnerUserManager.Instance.userInfo.Id,
                    TargetUserId = target.Id,
                    Message = message,
                    MessageTime = DateTime.Now
                });

            // 소켓으로 상대방에게 메세지 전달
            _ = WebSocketManager.Instance.Send(new SChatJSON(Constants.Chat, target.Id, message));
        }

        private void richTextBoxChat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift) // Shift+Enter는 줄바꿈
            {
                buttonSend.PerformClick();
                e.Handled = true;           // 이벤트 처리 완료
                e.SuppressKeyPress = true;  // 비프음 방지
            }
        }

        private void OnMessageReceived(RChatJSON msg)
        {
            if (InvokeRequired) 
                Invoke(() => AddMessage(msg.Message, DateTime.Now, false));
        }
    }
}
