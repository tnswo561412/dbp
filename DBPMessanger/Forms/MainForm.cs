using DBPMessanger.infos;
using DBPMessanger.Item;
using DBPMessanger.Items;
using DBPMessanger.Managers;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DBPMessanger.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // TODO
            // 직원 tab: treeview에 유저 정보 저장(UserInfo 형태로 저장)
            loadEmloyee();
            // 대화 목록 tab: 생성된 채팅방을 관리(추가)
            // 설정 tab: 회원정보 관리
        }

        private void loadEmloyee()
        {
            var departments = DBManager.Instance.Query<DepartmentInfo>(
                q => q.Include(d => d.Users)
                .OrderBy(d => d.Name)) ?? new List<DepartmentInfo>();

            if(departments.Count == 0)
                return;

            // 최상위 부서들 (ParentId가 null)
            var rootDepartments = departments
                .Where(d => d.ParentId == null)
                .OrderBy(d => d.Name);

            // TreeView 초기화
            treeViewEmployee.Nodes.Clear();

            // 최상위 부서부터 재귀적으로 TreeView 생성
            foreach (var dept in rootDepartments)
            {
                var deptNode = CreateDepartmentNode(dept, departments);
                treeViewEmployee.Nodes.Add(deptNode);
            }

            treeViewEmployee.ExpandAll();
        }

        private TreeNode CreateDepartmentNode(DepartmentInfo department, List<DepartmentInfo> allDepartments)
        {
            // 부서 노드 생성
            var deptNode = new TreeNode(department.Name);
            deptNode.Tag = department;

            // 하위 부서들 찾기
            var childDepartments = allDepartments
                .Where(d => d.ParentId == department.Id)
                .OrderBy(d => d.Name);

            // 하위 부서들을 재귀적으로 추가
            foreach (var childDept in childDepartments)
            {
                var childNode = CreateDepartmentNode(childDept, allDepartments);
                deptNode.Nodes.Add(childNode);
            }

            // 소속된 직원이 없으면 리턴
            if (department.Users == null)
                return deptNode;

            // 해당 부서 소속 직원들 추가
            foreach (var user in department.Users.OrderBy(u => u.Name))
            {
                var userNode = new TreeNode($"{user.Nickname}({user.Name})");
                userNode.Tag = user;
                deptNode.Nodes.Add(userNode);
            }

            return deptNode;
        }

        private void listBoxChats_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 선택된 아이템이 없으면 종료
            if (listBoxChats.SelectedItem == null)
                return;

            // Tag를 통해서 담아놨던 ChatItem 받아오기
            ChatItem item = (ChatItem)listBoxChats.SelectedItem;

            // 창이 없으면 새로 만들어주고 있으면 Focus
            ChatForm? form;
            if ((form = ChatFormManager.Instance.serachForm(item.target.Id)) == null)
            {
                form = new ChatForm(item.target.Id);
                ChatFormManager.Instance.Add(item.target.Id, form);
                form.Show();
            }
            else
            {
                form.Focus();
            }      
        }

        private void TreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            ChatForm? form;

            // 선택된 노드 Tag를 user에 저장
            if (selectedNode.Tag is UserInfo user)
            {
                // 본인을 선택 했을시 반환
                if (user.Id == OwnerUserManager.Instance.userInfo.Id)
                {
                    MessageBox.Show($"본인이랑 채팅할 수 없습니다");
                    return;
                }

                // 창이 켜져있다면 Focus
                if ((form = ChatFormManager.Instance.serachForm(user.Id)) != null)
                {
                    form.Focus();
                    return;
                }

                // 채팅 목록 item 추가

                // 가장 최근에 보낸 채팅 1개 가져오기
                var lastChat = DBManager.Instance.Query<ChatLogInfo>(
                    q => q.Where(c => (c.Sender.Id == user.Id
                    && c.Target.Id == OwnerUserManager.Instance.userInfo.Id)
                    || (c.Sender.Id == OwnerUserManager.Instance.userInfo.Id
                    && c.Target.Id == user.Id))
                    .OrderByDescending(c => c.MessageTime))?? Enumerable.Empty<ChatLogInfo>(); ;

                var chat = lastChat.FirstOrDefault();

                if (chat == null)
                    return;

                listBoxChats.Items.Add(new ChatItem(user, chat));

                // 채팅 폼 설정
                form = new ChatForm(user.Id);
                ChatFormManager.Instance.Add(user.Id, form);

                // 채팅 폼 실행
                form.Show();
            }
        }

        // listBox 설정
        private void listBoxChats_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            var item = listBoxChats.Items[e.Index] as ChatItem; // ChatItem: 사용자 + 메시지 + 시간 + 이미지

            e.DrawBackground();

            // 이미지
            //if (item.target.ProfileImage != null)
            //    e.Graphics.DrawImage(item.target.ProfileImage, new Rectangle(e.Bounds.X, e.Bounds.Y, 32, 32));

            // 이름
            e.Graphics.DrawString(item.target.Name, e.Font, Brushes.Black, e.Bounds.X + 50, e.Bounds.Y);

            // 시간
            e.Graphics.DrawString(item.chatLog.MessageTime.ToString("HH:mm"), e.Font, Brushes.Gray, e.Bounds.Right - 50, e.Bounds.Y);

            // 메시지
            e.Graphics.DrawString(item.chatLog.Message, e.Font, Brushes.Black, e.Bounds.X + 50, e.Bounds.Y + 16);

            e.DrawFocusRectangle();
        }
    }
}
