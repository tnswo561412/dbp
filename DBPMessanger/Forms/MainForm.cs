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

using DBPMessanger.Config;

namespace DBPMessanger.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // UI 스타일 적용
            ApplyModernUI();

            // TODO
            // 직원 tab: treeview에 유저 정보 저장(UserInfo 형태로 저장)
            loadEmloyee();
            // 대화 목록 tab: 생성된 채팅방을 관리(추가)
            loadChatList();
            // 설정 tab: 회원정보 관리
        }

        private void ApplyModernUI()
        {
            // 폼 전체 스타일
            this.BackColor = DBPMessanger.Controls.UITheme.BackgroundColor;
            this.Font = DBPMessanger.Controls.UITheme.DefaultFont;

            // TabControl 스타일 - 커스텀 드로잉 활성화
            tabControlChatList.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControlChatList.DrawItem += TabControlChatList_DrawItem;
            tabControlChatList.Font = DBPMessanger.Controls.UITheme.DefaultFont;

            // 탭 페이지 배경색
            tabPage1.BackColor = DBPMessanger.Controls.UITheme.BackgroundColor;
            tabPage2.BackColor = DBPMessanger.Controls.UITheme.BackgroundColor;
            tabPage3.BackColor = DBPMessanger.Controls.UITheme.BackgroundColor;

            // SplitContainer 스타일
            splitContainer1.BackColor = DBPMessanger.Controls.UITheme.BackgroundColor;
            splitContainer1.Panel1.BackColor = DBPMessanger.Controls.UITheme.SurfaceColor;
            splitContainer1.Panel2.BackColor = DBPMessanger.Controls.UITheme.BackgroundColor;
            splitContainer1.Panel1.Padding = new Padding(DBPMessanger.Controls.UITheme.PaddingMedium);
            splitContainer1.Panel2.Padding = new Padding(DBPMessanger.Controls.UITheme.PaddingMedium);

            splitContainerChatList.BackColor = DBPMessanger.Controls.UITheme.BackgroundColor;
            splitContainerChatList.Panel1.BackColor = DBPMessanger.Controls.UITheme.SurfaceColor;
            splitContainerChatList.Panel2.BackColor = DBPMessanger.Controls.UITheme.BackgroundColor;
            splitContainerChatList.Panel1.Padding = new Padding(DBPMessanger.Controls.UITheme.PaddingMedium);
            splitContainerChatList.Panel2.Padding = new Padding(DBPMessanger.Controls.UITheme.PaddingMedium);

            // Label 스타일
            label1.Font = DBPMessanger.Controls.UITheme.HeaderFont;
            label1.ForeColor = DBPMessanger.Controls.UITheme.TextPrimary;

            label2.Font = DBPMessanger.Controls.UITheme.HeaderFont;
            label2.ForeColor = DBPMessanger.Controls.UITheme.TextPrimary;

            label3.Font = DBPMessanger.Controls.UITheme.HeaderFont;
            label3.ForeColor = DBPMessanger.Controls.UITheme.TextPrimary;

            labelSearchResult.Font = DBPMessanger.Controls.UITheme.SmallFont;
            labelSearchResult.ForeColor = DBPMessanger.Controls.UITheme.TextSecondary;

            // TreeView 스타일
            treeViewEmployee.Font = DBPMessanger.Controls.UITheme.DefaultFont;
            treeViewEmployee.BackColor = DBPMessanger.Controls.UITheme.SurfaceColor;
            treeViewEmployee.ForeColor = DBPMessanger.Controls.UITheme.TextPrimary;
            treeViewEmployee.BorderStyle = BorderStyle.None;
            treeViewEmployee.ItemHeight = 28;
            treeViewEmployee.Dock = DockStyle.Fill;

            // ListBox 스타일
            listBoxChats.Font = DBPMessanger.Controls.UITheme.DefaultFont;
            listBoxChats.BackColor = DBPMessanger.Controls.UITheme.BackgroundColor;
            listBoxChats.BorderStyle = BorderStyle.None;
            listBoxChats.Dock = DockStyle.Fill;

            // 버튼 스타일
            ApplyButtonStyle(buttonSearch, DBPMessanger.Controls.UITheme.PrimaryColor);
            ApplyButtonStyle(buttonClearSearch, DBPMessanger.Controls.UITheme.SecondaryColor);
            ApplyButtonStyle(button_logout, DBPMessanger.Controls.UITheme.ErrorColor);

            // TextBox 스타일
            textBoxSearch.Font = DBPMessanger.Controls.UITheme.DefaultFont;
            textBoxSearch.BorderStyle = BorderStyle.FixedSingle;

            // ComboBox 스타일
            comboBoxSearchType.Font = DBPMessanger.Controls.UITheme.DefaultFont;
            comboBoxSearchType.FlatStyle = FlatStyle.Flat;
        }

        private void ApplyButtonStyle(System.Windows.Forms.Button button, Color backColor)
        {
            button.BackColor = backColor;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = DBPMessanger.Controls.UITheme.DefaultFont;
            button.Cursor = Cursors.Hand;
            button.Padding = new Padding(10, 5, 10, 5);
        }

        private void loadEmloyee()
        {
            // TreeView 초기화
            treeViewEmployee.Nodes.Clear();

            // 직원 즐겨찾기 사용자 로드 (Type = "EMPLOYEE")
            var favorites = DBManager.Instance.Query<FavoritesInfo>(
                q => q.Include(f => f.TargetUser)
                      .ThenInclude(u => u.Department)
                      .Where(f => f.UserId == OwnerUserManager.Instance.userInfo.Id
                               && f.Type == "EMPLOYEE"))
                ?? new List<FavoritesInfo>();

            // 즐겨찾기가 있으면 최상단에 표시
            if (favorites.Count > 0)
            {
                var favNode = new TreeNode("⭐ 즐겨찾기");
                favNode.Tag = "FAVORITES"; // 특별한 태그로 즐겨찾기 노드임을 표시

                foreach (var fav in favorites)
                {
                    if (fav.TargetUser != null)
                    {
                        var userNode = new TreeNode($"⭐ {fav.TargetUser.Nickname}({fav.TargetUser.Name})");
                        userNode.Tag = fav.TargetUser;
                        favNode.Nodes.Add(userNode);
                    }
                }

                treeViewEmployee.Nodes.Add(favNode);
            }

            // 부서 및 직원 로드
            var departments = DBManager.Instance.Query<DepartmentInfo>(
                q => q.Include(d => d.Users)
                .OrderBy(d => d.Name)) ?? new List<DepartmentInfo>();

            if (departments.Count == 0)
                return;

            // 최상위 부서들 (ParentId가 null)
            var rootDepartments = departments
                .Where(d => d.ParentId == null)
                .OrderBy(d => d.Name);

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

        private void listBoxChats_DoubleClick(object sender, EventArgs e)
        {
            // 선택된 아이템이 없으면 종료
            if (listBoxChats.SelectedItem == null)
                return;

            // 선택된 아이템으로 채팅창 열기
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

                // 채팅 폼 생성 및 실행
                form = new ChatForm(user.Id);
                ChatFormManager.Instance.Add(user.Id, form);
                form.Show();

                // 채팅 목록에 추가 (채팅 기록이 있는 경우에만)
                var lastChat = DBManager.Instance.Query<ChatLogInfo>(
                    q => q.Where(c => (c.SenderUserId == user.Id
                    && c.TargetUserId == OwnerUserManager.Instance.userInfo.Id)
                    || (c.SenderUserId == OwnerUserManager.Instance.userInfo.Id
                    && c.TargetUserId == user.Id))
                    .OrderByDescending(c => c.MessageTime))?.FirstOrDefault();

                if (lastChat != null)
                {
                    AddToChatList(user, lastChat);
                }
            }
        }

        // listBox 설정
        private void listBoxChats_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            var item = listBoxChats.Items[e.Index] as ChatItem;
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // 채팅 즐겨찾기 여부 확인 (Type = "CHAT")
            var isFavorite = DBManager.Instance.Query<FavoritesInfo>(
                q => q.Where(f => f.UserId == OwnerUserManager.Instance.userInfo.Id
                               && f.TargetUserId == item.target.Id
                               && f.Type == "CHAT"))
                ?.FirstOrDefault() != null;

            // 배경색 (선택/호버 상태)
            Color bgColor = DBPMessanger.Controls.UITheme.SurfaceColor;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                bgColor = DBPMessanger.Controls.UITheme.SelectedColor;

            using (SolidBrush bgBrush = new SolidBrush(bgColor))
            {
                g.FillRectangle(bgBrush, e.Bounds);
            }

            // 둥근 카드 배경
            Rectangle cardRect = new Rectangle(
                e.Bounds.X + 8,
                e.Bounds.Y + 4,
                e.Bounds.Width - 16,
                e.Bounds.Height - 8);

            using (System.Drawing.Drawing2D.GraphicsPath path = GetRoundedRectangle(cardRect, 12))
            {
                using (SolidBrush cardBrush = new SolidBrush(DBPMessanger.Controls.UITheme.CardBackground))
                {
                    g.FillPath(cardBrush, path);
                }

                // 카드 테두리 (선택 시)
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    using (Pen borderPen = new Pen(DBPMessanger.Controls.UITheme.PrimaryColor, 2))
                    {
                        g.DrawPath(borderPen, path);
                    }
                }
            }

            // 프로필 이미지 원형 배경
            int avatarSize = 44;
            int avatarX = cardRect.X + 12;
            int avatarY = cardRect.Y + (cardRect.Height - avatarSize) / 2;
            Rectangle avatarRect = new Rectangle(avatarX, avatarY, avatarSize, avatarSize);

            using (System.Drawing.Drawing2D.GraphicsPath circlePath = new System.Drawing.Drawing2D.GraphicsPath())
            {
                circlePath.AddEllipse(avatarRect);
                using (SolidBrush avatarBrush = new SolidBrush(DBPMessanger.Controls.UITheme.PrimaryLight))
                {
                    g.FillPath(avatarBrush, circlePath);
                }

                // 이니셜 표시
                string initial = item.target.Name.Length > 0 ? item.target.Name.Substring(0, 1).ToUpper() : "?";
                using (Font initialFont = new Font("Segoe UI", 16F, FontStyle.Bold))
                using (SolidBrush initialBrush = new SolidBrush(Color.White))
                {
                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    g.DrawString(initial, initialFont, initialBrush, avatarRect, sf);
                }
            }

            // 텍스트 영역
            int textX = avatarX + avatarSize + 12;
            int textWidth = cardRect.Right - textX - 70;

            // 이름 (즐겨찾기면 ⭐ 추가)
            string displayName = isFavorite ? $"⭐ {item.target.Name}" : item.target.Name;
            using (Font nameFont = new Font(new FontFamily("Segoe UI"), 10.5F, FontStyle.Bold))
            using (SolidBrush nameBrush = new SolidBrush(DBPMessanger.Controls.UITheme.TextPrimary))
            {
                g.DrawString(displayName, nameFont, nameBrush, textX, cardRect.Y + 10);
            }

            // 채팅 기록이 있을 때만 시간과 메시지 표시
            if (item.chatLog != null)
            {
                // 시간
                string timeStr = item.chatLog.MessageTime.ToString("HH:mm");
                Font timeFont = DBPMessanger.Controls.UITheme.SmallFont;
                using (SolidBrush timeBrush = new SolidBrush(DBPMessanger.Controls.UITheme.TextSecondary))
                {
                    SizeF timeSize = g.MeasureString(timeStr, timeFont);
                    g.DrawString(timeStr, timeFont, timeBrush,
                        cardRect.Right - timeSize.Width - 12, cardRect.Y + 10);
                }

                // 메시지 (말줄임표 처리)
                string message = item.chatLog.Message;
                if (message.Length > 40)
                    message = message.Substring(0, 40) + "...";

                Font msgFont = DBPMessanger.Controls.UITheme.DefaultFont;
                using (SolidBrush msgBrush = new SolidBrush(DBPMessanger.Controls.UITheme.TextSecondary))
                {
                    g.DrawString(message, msgFont, msgBrush, textX, cardRect.Y + 32);
                }
            }
        }

        private System.Drawing.Drawing2D.GraphicsPath GetRoundedRectangle(Rectangle rect, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int diameter = radius * 2;

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }

        private void TabControlChatList_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            TabPage tabPage = tabControlChatList.TabPages[e.Index];
            Rectangle tabRect = tabControlChatList.GetTabRect(e.Index);

            // 선택된 탭인지 확인
            bool isSelected = (e.Index == tabControlChatList.SelectedIndex);

            // 배경색
            Color bgColor = isSelected
                ? DBPMessanger.Controls.UITheme.PrimaryColor
                : DBPMessanger.Controls.UITheme.SurfaceColor;

            using (SolidBrush bgBrush = new SolidBrush(bgColor))
            {
                g.FillRectangle(bgBrush, tabRect);
            }

            // 아이콘 (유니코드 문자 사용)
            string icon = "";
            Color iconColor = isSelected ? Color.White : DBPMessanger.Controls.UITheme.TextPrimary;

            switch (e.Index)
            {
                case 0: // 직원
                    icon = "👤";
                    break;
                case 1: // 채팅목록
                    icon = "💬";
                    break;
                case 2: // 설정
                    icon = "⚙";
                    break;
            }

            using (Font iconFont = new Font(new FontFamily("Segoe UI Emoji"), 20F, FontStyle.Regular))
            using (SolidBrush iconBrush = new SolidBrush(iconColor))
            {
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString(icon, iconFont, iconBrush, tabRect, sf);
            }
        }

        private void button_logout_Click(object sender, EventArgs e)
        {
            LogoutHelper.PerformLogout();
            _ = WebSocketManager.Instance.Disconnect();
            Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // 사용자가 강제로 닫은 경우도 처리
            LogoutHelper.PerformLogout();
            base.OnFormClosed(e);
        }

        // ========== 검색 기능 ==========
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void buttonClearSearch_Click(object sender, EventArgs e)
        {
            textBoxSearch.Clear();
            labelSearchResult.Text = "";
            loadEmloyee(); // 전체 목록 복원
        }

        private void textBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Enter 키 누르면 검색
            if (e.KeyChar == (char)Keys.Enter)
            {
                PerformSearch();
                e.Handled = true; // 비프음 방지
            }
        }

        private void PerformSearch()
        {
            string searchText = textBoxSearch?.Text?.Trim() ?? "";

            if (string.IsNullOrEmpty(searchText))
            {
                loadEmloyee(); // 검색어가 없으면 전체 목록 표시
                return;
            }

            var searchType = comboBoxSearchType?.SelectedIndex ?? 0;

            // 모든 사용자 조회
            var allUsers = DBManager.Instance.Query<UserInfo>(
                q => q.Include(u => u.Department)) ?? new List<UserInfo>();

            // 현재 사용자 제외
            allUsers = allUsers.Where(u => u.Id != OwnerUserManager.Instance.userInfo.Id).ToList();

            // 권한 필터링 (AuthorityUserInfo, AuthorityDepartmentInfo 확인)
            allUsers = FilterByAuthority(allUsers);

            List<UserInfo> filteredUsers = new List<UserInfo>();

            switch (searchType)
            {
                case 0: // 전체 검색 (ID, 이름, 부서 모두)
                    filteredUsers = allUsers
                        .Where(u => u.LoginId.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                                 || u.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                                 || u.Nickname.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                                 || (u.Department?.Name?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true))
                        .ToList();
                    break;
                case 1: // ID 기반 검색
                    filteredUsers = allUsers
                        .Where(u => u.LoginId.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                    break;
                case 2: // 이름 기반 검색
                    filteredUsers = allUsers
                        .Where(u => u.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                                 || u.Nickname.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                    break;
                case 3: // 부서 기반 검색
                    filteredUsers = allUsers
                        .Where(u => u.Department?.Name?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true)
                        .ToList();
                    break;
            }

            // TreeView에 검색 결과 표시
            DisplaySearchResults(filteredUsers);

            // 검색 결과 수 표시
            labelSearchResult.Text = $"검색 결과: {filteredUsers.Count}명";
        }

        private List<UserInfo> FilterByAuthority(List<UserInfo> users)
        {
            long currentUserId = OwnerUserManager.Instance.userInfo.Id;

            // 사용자별 권한 확인
            var userAuthorities = DBManager.Instance.Query<AuthorityUserInfo>(
                q => q.Where(a => a.UserId == currentUserId && a.CanView == false))
                ?? new List<AuthorityUserInfo>();

            // 부서별 권한 확인
            var deptAuthorities = DBManager.Instance.Query<AuthorityDepartmentInfo>(
                q => q.Where(a => a.UserId == currentUserId && a.CanView == false))
                ?? new List<AuthorityDepartmentInfo>();

            // 권한이 없는 사용자 필터링
            var blockedUserIds = userAuthorities.Select(a => a.TargetUserId).ToList();
            var blockedDeptIds = deptAuthorities.Select(a => a.TargetUserId).ToList();

            return users.Where(u =>
                !blockedUserIds.Contains(u.Id) &&
                !blockedDeptIds.Contains(u.DepartmentId)).ToList();
        }

        private void DisplaySearchResults(List<UserInfo> users)
        {
            treeViewEmployee.Nodes.Clear();

            if (users.Count == 0)
            {
                var emptyNode = new TreeNode("검색 결과가 없습니다.");
                treeViewEmployee.Nodes.Add(emptyNode);
                return;
            }

            // 검색 결과를 부서별로 그룹화
            var groupedByDept = users.GroupBy(u => u.Department?.Name ?? "부서 없음");

            foreach (var group in groupedByDept)
            {
                var deptNode = new TreeNode(group.Key);

                foreach (var user in group)
                {
                    var userNode = new TreeNode($"{user.Nickname}({user.Name}) - {user.LoginId}");
                    userNode.Tag = user;
                    deptNode.Nodes.Add(userNode);
                }

                treeViewEmployee.Nodes.Add(deptNode);
            }

            treeViewEmployee.ExpandAll();
        }

        // ========== 즐겨찾기 기능 ==========
        private void buttonAddFavorite_Click(object sender, EventArgs e)
        {
            TreeNode? selectedNode = treeViewEmployee.SelectedNode;

            if (selectedNode?.Tag is UserInfo user)
            {
                // 이미 직원 즐겨찾기에 있는지 확인
                var existing = DBManager.Instance.Query<FavoritesInfo>(
                    q => q.Where(f => f.UserId == OwnerUserManager.Instance.userInfo.Id
                                   && f.TargetUserId == user.Id
                                   && f.Type == "EMPLOYEE"))
                    ?.FirstOrDefault();

                if (existing != null)
                {
                    MessageBox.Show("이미 즐겨찾기에 추가된 사용자입니다.", "즐겨찾기",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 직원 즐겨찾기 추가
                var favorite = new FavoritesInfo
                {
                    UserId = OwnerUserManager.Instance.userInfo.Id,
                    TargetUserId = user.Id,
                    Type = "EMPLOYEE"
                };

                DBManager.Instance.Insert(favorite);
                MessageBox.Show($"{user.Name}님을 직원 즐겨찾기에 추가했습니다.", "즐겨찾기",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                loadEmloyee(); // TreeView 새로고침
            }
            else
            {
                MessageBox.Show("사용자를 선택해주세요.", "즐겨찾기",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ========== 우클릭 메뉴 ==========
        private void menuItemStartChat_Click(object sender, EventArgs e)
        {
            TreeNode? selectedNode = treeViewEmployee.SelectedNode;
            if (selectedNode?.Tag is UserInfo user)
            {
                OpenChatWithUser(user);
            }
        }

        private void menuItemAddFavorite_Click(object sender, EventArgs e)
        {
            buttonAddFavorite_Click(sender, e);
        }

        // ========== 대화 목록 관리 ==========
        private void loadChatList()
        {
            listBoxChats.Items.Clear();

            // 채팅 즐겨찾기 목록 조회 (Type = "CHAT", DisplayOrder 순으로 정렬)
            var favorites = DBManager.Instance.Query<FavoritesInfo>(
                q => q.Include(f => f.TargetUser)
                      .Where(f => f.UserId == OwnerUserManager.Instance.userInfo.Id
                               && f.Type == "CHAT")
                      .OrderBy(f => f.DisplayOrder))
                ?? new List<FavoritesInfo>();

            var favoriteUserIds = favorites.Select(f => f.TargetUserId).ToHashSet();

            // 현재 사용자가 참여한 모든 대화 조회 (최근 순으로 정렬)
            var chats = DBManager.Instance.Query<ChatLogInfo>(
                q => q.Include(c => c.Sender)
                      .Include(c => c.Target)
                      .Where(c => c.SenderUserId == OwnerUserManager.Instance.userInfo.Id
                               || c.TargetUserId == OwnerUserManager.Instance.userInfo.Id)
                      .OrderByDescending(c => c.MessageTime))
                ?? new List<ChatLogInfo>();

            // 대화 상대별로 그룹화하고 최근 메시지만 표시
            var groupedChats = chats
                .GroupBy(c => c.SenderUserId == OwnerUserManager.Instance.userInfo.Id
                    ? c.TargetUserId
                    : c.SenderUserId)
                .Select(g => g.First())
                .ToList();

            // ChatItem 리스트 생성
            var chatItems = new List<ChatItem>();
            foreach (var chat in groupedChats)
            {
                var targetUser = chat.SenderUserId == OwnerUserManager.Instance.userInfo.Id
                    ? chat.Target
                    : chat.Sender;

                if (targetUser != null)
                {
                    chatItems.Add(new ChatItem(targetUser, chat));
                }
            }

            // 즐겨찾기 항목을 DisplayOrder 순으로 추가
            foreach (var fav in favorites)
            {
                if (fav.TargetUser != null)
                {
                    // 해당 사용자의 최근 채팅 로그 찾기
                    var chatLog = chatItems
                        .FirstOrDefault(item => item.target.Id == fav.TargetUserId)?.chatLog;

                    listBoxChats.Items.Add(new ChatItem(fav.TargetUser, chatLog));
                }
            }

            // 일반 항목을 최근 채팅 순으로 추가
            var normalChatItems = chatItems.Where(item => !favoriteUserIds.Contains(item.target.Id)).ToList();
            foreach (var item in normalChatItems)
            {
                listBoxChats.Items.Add(item);
            }
        }

        public void RefreshChatList()
        {
            loadChatList();
        }

        public void AddToChatList(UserInfo user, ChatLogInfo? lastChat)
        {
            // 이미 목록에 있는지 확인
            for (int i = 0; i < listBoxChats.Items.Count; i++)
            {
                if (listBoxChats.Items[i] is ChatItem item && item.target.Id == user.Id)
                {
                    // 이미 있으면 업데이트 (lastChat이 null이 아닐 때만)
                    if (lastChat != null)
                    {
                        listBoxChats.Items[i] = new ChatItem(user, lastChat);
                        listBoxChats.Invalidate();
                    }
                    return;
                }
            }

            // 없으면 추가
            listBoxChats.Items.Insert(0, new ChatItem(user, lastChat));
        }

        private void OpenChatWithUser(UserInfo user)
        {
            ChatForm? form;

            // 본인 체크
            if (user.Id == OwnerUserManager.Instance.userInfo.Id)
            {
                MessageBox.Show("본인과 채팅할 수 없습니다.", "채팅",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 창이 켜져있다면 Focus
            if ((form = ChatFormManager.Instance.serachForm(user.Id)) != null)
            {
                form.Focus();
                return;
            }

            // 채팅 폼 생성
            form = new ChatForm(user.Id);
            ChatFormManager.Instance.Add(user.Id, form);
            form.Show();

            // 채팅 목록에 추가
            var lastChat = DBManager.Instance.Query<ChatLogInfo>(
                q => q.Where(c => (c.SenderUserId == user.Id && c.TargetUserId == OwnerUserManager.Instance.userInfo.Id)
                               || (c.SenderUserId == OwnerUserManager.Instance.userInfo.Id && c.TargetUserId == user.Id))
                      .OrderByDescending(c => c.MessageTime))
                ?.FirstOrDefault();

            // 채팅 기록이 없어도 채팅목록에 추가 (null로 전달)
            AddToChatList(user, lastChat);
        }

        // ========== TreeView 우클릭 자동 선택 ==========
        private void treeViewEmployee_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // 우클릭 시 자동으로 해당 노드 선택
            if (e.Button == MouseButtons.Right)
            {
                treeViewEmployee.SelectedNode = e.Node;
            }
        }

        // ========== TreeView 드래그 앤 드롭 (즐겨찾기 순서 변경) ==========
        private void treeViewEmployee_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Item is TreeNode node && node.Tag is UserInfo)
            {
                // 즐겨찾기 노드 안의 아이템만 드래그 가능
                if (node.Parent?.Tag as string == "FAVORITES")
                {
                    DoDragDrop(node, DragDropEffects.Move);
                }
            }
        }

        private void treeViewEmployee_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data?.GetDataPresent(typeof(TreeNode)) == true)
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void treeViewEmployee_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data?.GetData(typeof(TreeNode)) is not TreeNode draggedNode)
                return;

            Point targetPoint = treeViewEmployee.PointToClient(new Point(e.X, e.Y));
            TreeNode? targetNode = treeViewEmployee.GetNodeAt(targetPoint);

            if (targetNode == null)
                return;

            // 즐겨찾기 노드 내에서만 이동 가능
            TreeNode? favoritesNode = draggedNode.Parent;
            if (favoritesNode?.Tag as string != "FAVORITES")
                return;

            // 같은 즐겨찾기 노드 안에서만 재배치
            if (targetNode.Parent == favoritesNode || targetNode == favoritesNode)
            {
                int targetIndex;
                if (targetNode == favoritesNode)
                {
                    targetIndex = 0;
                }
                else
                {
                    targetIndex = targetNode.Index;
                }

                // 노드 이동
                favoritesNode.Nodes.Remove(draggedNode);
                favoritesNode.Nodes.Insert(targetIndex, draggedNode);
                treeViewEmployee.SelectedNode = draggedNode;
            }
        }

        // ========== ListBox 드래그 앤 드롭 (대화 목록 즐겨찾기 순서 변경) ==========
        private int dragStartIndex = -1;
        private Point dragStartPoint;

        private void listBoxChats_MouseDown(object sender, MouseEventArgs e)
        {
            if (listBoxChats.Items.Count == 0)
                return;

            int index = listBoxChats.IndexFromPoint(e.X, e.Y);
            if (index != -1)
            {
                // 항목 선택
                listBoxChats.SelectedIndex = index;

                // 좌클릭 시 드래그 준비
                if (e.Button == MouseButtons.Left)
                {
                    dragStartIndex = index;
                    dragStartPoint = new Point(e.X, e.Y);
                }
            }
        }

        private void listBoxChats_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && dragStartIndex != -1)
            {
                // 일정 거리 이상 움직였을 때만 드래그 시작
                if (Math.Abs(e.X - dragStartPoint.X) > 5 || Math.Abs(e.Y - dragStartPoint.Y) > 5)
                {
                    var item = listBoxChats.Items[dragStartIndex] as ChatItem;
                    if (item == null)
                        return;

                    // 즐겨찾기 항목만 드래그 가능
                    var isFavorite = DBManager.Instance.Query<FavoritesInfo>(
                        q => q.Where(f => f.UserId == OwnerUserManager.Instance.userInfo.Id
                                       && f.TargetUserId == item.target.Id
                                       && f.Type == "CHAT"))
                        ?.FirstOrDefault() != null;

                    if (isFavorite)
                    {
                        listBoxChats.DoDragDrop(item, DragDropEffects.Move);
                    }
                }
            }
        }

        private void listBoxChats_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data?.GetDataPresent(typeof(ChatItem)) == true)
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void listBoxChats_DragDrop(object sender, DragEventArgs e)
        {
            Point point = listBoxChats.PointToClient(new Point(e.X, e.Y));
            int targetIndex = listBoxChats.IndexFromPoint(point);

            if (targetIndex == -1)
                targetIndex = listBoxChats.Items.Count - 1;

            if (dragStartIndex != -1 && targetIndex != -1 && dragStartIndex != targetIndex)
            {
                var draggedItem = listBoxChats.Items[dragStartIndex] as ChatItem;
                var targetItem = listBoxChats.Items[targetIndex] as ChatItem;

                if (draggedItem == null || targetItem == null)
                    return;

                // 채팅 즐겨찾기 여부 확인 (Type = "CHAT")
                var draggedIsFavorite = DBManager.Instance.Query<FavoritesInfo>(
                    q => q.Where(f => f.UserId == OwnerUserManager.Instance.userInfo.Id
                                   && f.TargetUserId == draggedItem.target.Id
                                   && f.Type == "CHAT"))
                    ?.FirstOrDefault() != null;

                var targetIsFavorite = DBManager.Instance.Query<FavoritesInfo>(
                    q => q.Where(f => f.UserId == OwnerUserManager.Instance.userInfo.Id
                                   && f.TargetUserId == targetItem.target.Id
                                   && f.Type == "CHAT"))
                    ?.FirstOrDefault() != null;

                // 즐겨찾기 항목만 이동 가능 (일반 항목은 최근 순으로 고정)
                if (draggedIsFavorite && targetIsFavorite)
                {
                    // UI에서 항목 이동
                    listBoxChats.Items.RemoveAt(dragStartIndex);
                    listBoxChats.Items.Insert(targetIndex, draggedItem);
                    listBoxChats.SelectedIndex = targetIndex;

                    // DB에 DisplayOrder 업데이트
                    UpdateFavoriteDisplayOrder();
                }
                else
                {
                    MessageBox.Show("즐겨찾기 항목만 순서를 변경할 수 있습니다.\n일반 항목은 최근 채팅 순으로 자동 정렬됩니다.", "알림",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            dragStartIndex = -1;
        }

        private void UpdateFavoriteDisplayOrder()
        {
            // 현재 리스트에서 즐겨찾기 항목들의 순서를 DB에 저장
            int displayOrder = 0;

            foreach (var item in listBoxChats.Items)
            {
                if (item is ChatItem chatItem)
                {
                    var favorite = DBManager.Instance.Query<FavoritesInfo>(
                        q => q.Where(f => f.UserId == OwnerUserManager.Instance.userInfo.Id
                                       && f.TargetUserId == chatItem.target.Id
                                       && f.Type == "CHAT"))
                        ?.FirstOrDefault();

                    if (favorite != null)
                    {
                        // 즐겨찾기 항목이면 DisplayOrder 업데이트
                        favorite.DisplayOrder = displayOrder;
                        DBManager.Instance.Update(favorite);
                        displayOrder++;
                    }
                    else
                    {
                        // 일반 항목 시작 지점이면 반복 종료
                        break;
                    }
                }
            }
        }

        // ========== 컨텍스트 메뉴 동적 표시 ==========
        private void contextMenuEmployee_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TreeNode? selectedNode = treeViewEmployee.SelectedNode;
            if (selectedNode?.Tag is UserInfo user)
            {
                // 직원 즐겨찾기 여부 확인 (Type = "EMPLOYEE")
                var existing = DBManager.Instance.Query<FavoritesInfo>(
                    q => q.Where(f => f.UserId == OwnerUserManager.Instance.userInfo.Id
                                   && f.TargetUserId == user.Id
                                   && f.Type == "EMPLOYEE"))
                    ?.FirstOrDefault();

                // 이미 즐겨찾기면 "추가" 숨기고 "삭제" 표시
                menuItemAddFavorite.Visible = (existing == null);
                menuItemRemoveFavorite.Visible = (existing != null);
            }
            else
            {
                // 사용자가 아니면 메뉴 취소
                e.Cancel = true;
            }
        }

        private void contextMenuChatList_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (listBoxChats.SelectedItem is ChatItem item)
            {
                // 채팅 즐겨찾기 여부 확인 (Type = "CHAT")
                var existing = DBManager.Instance.Query<FavoritesInfo>(
                    q => q.Where(f => f.UserId == OwnerUserManager.Instance.userInfo.Id
                                   && f.TargetUserId == item.target.Id
                                   && f.Type == "CHAT"))
                    ?.FirstOrDefault();

                // 이미 즐겨찾기면 "추가" 숨기고 "삭제" 표시
                menuItemChatFavorite.Visible = (existing == null);
                menuItemChatUnfavorite.Visible = (existing != null);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void menuItemRemoveFavorite_Click(object sender, EventArgs e)
        {
            TreeNode? selectedNode = treeViewEmployee.SelectedNode;
            if (selectedNode?.Tag is UserInfo user)
            {
                var favorite = DBManager.Instance.Query<FavoritesInfo>(
                    q => q.Where(f => f.UserId == OwnerUserManager.Instance.userInfo.Id
                                   && f.TargetUserId == user.Id
                                   && f.Type == "EMPLOYEE"))
                    ?.FirstOrDefault();

                if (favorite != null)
                {
                    DBManager.Instance.Delete(favorite);
                    MessageBox.Show($"{user.Name}님을 직원 즐겨찾기에서 삭제했습니다.", "즐겨찾기",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    loadEmloyee(); // TreeView 새로고침
                }
            }
        }

        private void menuItemChatFavorite_Click(object sender, EventArgs e)
        {
            if (listBoxChats.SelectedItem is ChatItem item)
            {
                // 이미 채팅 즐겨찾기에 있는지 확인
                var existing = DBManager.Instance.Query<FavoritesInfo>(
                    q => q.Where(f => f.UserId == OwnerUserManager.Instance.userInfo.Id
                                   && f.TargetUserId == item.target.Id
                                   && f.Type == "CHAT"))
                    ?.FirstOrDefault();

                if (existing != null)
                {
                    MessageBox.Show("이미 즐겨찾기에 추가된 사용자입니다.", "즐겨찾기",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 현재 채팅 즐겨찾기 개수 확인하여 DisplayOrder 설정
                var maxDisplayOrder = DBManager.Instance.Query<FavoritesInfo>(
                    q => q.Where(f => f.UserId == OwnerUserManager.Instance.userInfo.Id
                                   && f.Type == "CHAT"))
                    ?.Max(f => (int?)f.DisplayOrder) ?? -1;

                // 채팅 즐겨찾기 추가
                var favorite = new FavoritesInfo
                {
                    UserId = OwnerUserManager.Instance.userInfo.Id,
                    TargetUserId = item.target.Id,
                    Type = "CHAT",
                    DisplayOrder = maxDisplayOrder + 1
                };

                DBManager.Instance.Insert(favorite);
                MessageBox.Show($"{item.target.Name}님을 채팅 즐겨찾기에 추가했습니다.", "즐겨찾기",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                loadChatList(); // 대화 목록 새로고침
            }
        }

        private void menuItemChatUnfavorite_Click(object sender, EventArgs e)
        {
            if (listBoxChats.SelectedItem is ChatItem item)
            {
                var favorite = DBManager.Instance.Query<FavoritesInfo>(
                    q => q.Where(f => f.UserId == OwnerUserManager.Instance.userInfo.Id
                                   && f.TargetUserId == item.target.Id
                                   && f.Type == "CHAT"))
                    ?.FirstOrDefault();

                if (favorite != null)
                {
                    DBManager.Instance.Delete(favorite);
                    MessageBox.Show($"{item.target.Name}님을 채팅 즐겨찾기에서 삭제했습니다.", "즐겨찾기",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    loadChatList(); // 대화 목록 새로고침
                }
            }
        }
    }
}
