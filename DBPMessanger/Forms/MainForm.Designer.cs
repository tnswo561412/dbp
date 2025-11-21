namespace DBPMessanger.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tabControlChatList = new TabControl();
            tabPage1 = new TabPage();
            splitContainer1 = new SplitContainer();
            label2 = new Label();
            textBoxSearch = new TextBox();
            comboBoxSearchType = new ComboBox();
            buttonSearch = new Button();
            buttonClearSearch = new Button();
            labelSearchResult = new Label();
            treeViewEmployee = new TreeView();
            contextMenuEmployee = new ContextMenuStrip(components);
            menuItemStartChat = new ToolStripMenuItem();
            menuItemAddFavorite = new ToolStripMenuItem();
            menuItemRemoveFavorite = new ToolStripMenuItem();
            tabPage2 = new TabPage();
            splitContainerChatList = new SplitContainer();
            label1 = new Label();
            listBoxChats = new ListBox();
            tabPage3 = new TabPage();
            label3 = new Label();
            contextMenuChatList = new ContextMenuStrip(components);
            menuItemChatFavorite = new ToolStripMenuItem();
            menuItemChatUnfavorite = new ToolStripMenuItem();
            imageList = new ImageList(components);
            button_logout = new Button();
            tabControlChatList.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerChatList).BeginInit();
            splitContainerChatList.Panel1.SuspendLayout();
            splitContainerChatList.Panel2.SuspendLayout();
            splitContainerChatList.SuspendLayout();
            SuspendLayout();
            //
            // tabControlChatList
            //
            tabControlChatList.Alignment = TabAlignment.Left;
            tabControlChatList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControlChatList.Controls.Add(tabPage1);
            tabControlChatList.Controls.Add(tabPage2);
            tabControlChatList.Controls.Add(tabPage3);
            tabControlChatList.Font = new Font("Segoe UI", 9F);
            tabControlChatList.ImageList = imageList;
            tabControlChatList.ItemSize = new Size(60, 60);
            tabControlChatList.Location = new Point(12, 12);
            tabControlChatList.Multiline = true;
            tabControlChatList.Name = "tabControlChatList";
            tabControlChatList.Padding = new Point(15, 3);
            tabControlChatList.SelectedIndex = 0;
            tabControlChatList.Size = new Size(876, 626);
            tabControlChatList.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(splitContainer1);
            tabPage1.ImageIndex = 0;
            tabPage1.Location = new Point(54, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(325, 584);
            tabPage1.TabIndex = 0;
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            //
            // splitContainer1.Panel1
            //
            splitContainer1.Panel1.Controls.Add(labelSearchResult);
            splitContainer1.Panel1.Controls.Add(buttonClearSearch);
            splitContainer1.Panel1.Controls.Add(buttonSearch);
            splitContainer1.Panel1.Controls.Add(comboBoxSearchType);
            splitContainer1.Panel1.Controls.Add(textBoxSearch);
            splitContainer1.Panel1.Controls.Add(label2);
            //
            // splitContainer1.Panel2
            //
            splitContainer1.Panel2.Controls.Add(treeViewEmployee);
            splitContainer1.Size = new Size(319, 578);
            splitContainer1.SplitterDistance = 115;
            splitContainer1.TabIndex = 0;
            // 
            // label2
            //
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 20F);
            label2.Location = new Point(12, 10);
            label2.Name = "label2";
            label2.Size = new Size(71, 37);
            label2.TabIndex = 0;
            label2.Text = "직원";
            //
            // textBoxSearch
            //
            textBoxSearch.Location = new Point(12, 55);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "검색어 입력...";
            textBoxSearch.Size = new Size(150, 23);
            textBoxSearch.TabIndex = 1;
            textBoxSearch.KeyPress += textBoxSearch_KeyPress;
            //
            // comboBoxSearchType
            //
            comboBoxSearchType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSearchType.FormattingEnabled = true;
            comboBoxSearchType.Items.AddRange(new object[] { "전체", "ID", "이름", "부서" });
            comboBoxSearchType.Location = new Point(168, 55);
            comboBoxSearchType.Name = "comboBoxSearchType";
            comboBoxSearchType.Size = new Size(70, 23);
            comboBoxSearchType.TabIndex = 2;
            comboBoxSearchType.SelectedIndex = 0;
            //
            // buttonSearch
            //
            buttonSearch.Location = new Point(244, 55);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(70, 28);
            buttonSearch.TabIndex = 3;
            buttonSearch.Text = "검색";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            //
            // buttonClearSearch
            //
            buttonClearSearch.Location = new Point(12, 84);
            buttonClearSearch.Name = "buttonClearSearch";
            buttonClearSearch.Size = new Size(85, 28);
            buttonClearSearch.TabIndex = 4;
            buttonClearSearch.Text = "초기화";
            buttonClearSearch.UseVisualStyleBackColor = true;
            buttonClearSearch.Click += buttonClearSearch_Click;
            //
            // labelSearchResult
            //
            labelSearchResult.AutoSize = true;
            labelSearchResult.ForeColor = SystemColors.ControlDarkDark;
            labelSearchResult.Location = new Point(98, 88);
            labelSearchResult.Name = "labelSearchResult";
            labelSearchResult.Size = new Size(0, 15);
            labelSearchResult.TabIndex = 5;
            //
            // treeViewEmployee
            //
            treeViewEmployee.AllowDrop = true;
            treeViewEmployee.ContextMenuStrip = contextMenuEmployee;
            treeViewEmployee.Location = new Point(3, 3);
            treeViewEmployee.Name = "treeViewEmployee";
            treeViewEmployee.Size = new Size(313, 420);
            treeViewEmployee.TabIndex = 0;
            treeViewEmployee.ItemDrag += treeViewEmployee_ItemDrag;
            treeViewEmployee.DragEnter += treeViewEmployee_DragEnter;
            treeViewEmployee.DragDrop += treeViewEmployee_DragDrop;
            treeViewEmployee.NodeMouseClick += treeViewEmployee_NodeMouseClick;
            treeViewEmployee.NodeMouseDoubleClick += TreeView1_NodeMouseDoubleClick;
            //
            // contextMenuEmployee
            //
            contextMenuEmployee.Items.AddRange(new ToolStripItem[] { menuItemStartChat, menuItemAddFavorite, menuItemRemoveFavorite });
            contextMenuEmployee.Name = "contextMenuEmployee";
            contextMenuEmployee.Size = new Size(160, 70);
            contextMenuEmployee.Opening += contextMenuEmployee_Opening;
            //
            // menuItemStartChat
            //
            menuItemStartChat.Name = "menuItemStartChat";
            menuItemStartChat.Size = new Size(159, 22);
            menuItemStartChat.Text = "💬 채팅 시작";
            menuItemStartChat.Click += menuItemStartChat_Click;
            //
            // menuItemAddFavorite
            //
            menuItemAddFavorite.Name = "menuItemAddFavorite";
            menuItemAddFavorite.Size = new Size(179, 22);
            menuItemAddFavorite.Text = "⭐ 즐겨찾기 추가";
            menuItemAddFavorite.Click += menuItemAddFavorite_Click;
            //
            // menuItemRemoveFavorite
            //
            menuItemRemoveFavorite.Name = "menuItemRemoveFavorite";
            menuItemRemoveFavorite.Size = new Size(179, 22);
            menuItemRemoveFavorite.Text = "⭐ 즐겨찾기 삭제";
            menuItemRemoveFavorite.Click += menuItemRemoveFavorite_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(splitContainerChatList);
            tabPage2.ImageIndex = 1;
            tabPage2.Location = new Point(54, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(325, 584);
            tabPage2.TabIndex = 1;
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainerChatList
            // 
            splitContainerChatList.Dock = DockStyle.Fill;
            splitContainerChatList.Location = new Point(3, 3);
            splitContainerChatList.Name = "splitContainerChatList";
            splitContainerChatList.Orientation = Orientation.Horizontal;
            // 
            // splitContainerChatList.Panel1
            // 
            splitContainerChatList.Panel1.Controls.Add(label1);
            // 
            // splitContainerChatList.Panel2
            // 
            splitContainerChatList.Panel2.Controls.Add(listBoxChats);
            splitContainerChatList.Size = new Size(319, 578);
            splitContainerChatList.SplitterDistance = 94;
            splitContainerChatList.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 20F);
            label1.Location = new Point(12, 26);
            label1.Name = "label1";
            label1.Size = new Size(125, 37);
            label1.TabIndex = 0;
            label1.Text = "채팅목록";
            //
            // listBoxChats
            //
            listBoxChats.AllowDrop = true;
            listBoxChats.ContextMenuStrip = contextMenuChatList;
            listBoxChats.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxChats.FormattingEnabled = true;
            listBoxChats.ItemHeight = 70;
            listBoxChats.Location = new Point(0, 3);
            listBoxChats.Name = "listBoxChats";
            listBoxChats.Size = new Size(325, 484);
            listBoxChats.TabIndex = 3;
            listBoxChats.DrawItem += listBoxChats_DrawItem;
            listBoxChats.DoubleClick += listBoxChats_DoubleClick;
            listBoxChats.MouseDown += listBoxChats_MouseDown;
            listBoxChats.MouseMove += listBoxChats_MouseMove;
            listBoxChats.DragEnter += listBoxChats_DragEnter;
            listBoxChats.DragDrop += listBoxChats_DragDrop;
            //
            // tabPage3
            //
            tabPage3.Controls.Add(label3);
            tabPage3.ImageIndex = 2;
            tabPage3.Location = new Point(54, 4);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(325, 584);
            tabPage3.TabIndex = 2;
            tabPage3.UseVisualStyleBackColor = true;
            //
            // label3
            //
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 20F);
            label3.Location = new Point(15, 20);
            label3.Name = "label3";
            label3.Size = new Size(71, 37);
            label3.TabIndex = 0;
            label3.Text = "설정";
            //
            // contextMenuChatList
            //
            contextMenuChatList.Items.AddRange(new ToolStripItem[] { menuItemChatFavorite, menuItemChatUnfavorite });
            contextMenuChatList.Name = "contextMenuChatList";
            contextMenuChatList.Size = new Size(160, 48);
            contextMenuChatList.Opening += contextMenuChatList_Opening;
            //
            // menuItemChatFavorite
            //
            menuItemChatFavorite.Name = "menuItemChatFavorite";
            menuItemChatFavorite.Size = new Size(159, 22);
            menuItemChatFavorite.Text = "⭐ 즐겨찾기 추가";
            menuItemChatFavorite.Click += menuItemChatFavorite_Click;
            //
            // menuItemChatUnfavorite
            //
            menuItemChatUnfavorite.Name = "menuItemChatUnfavorite";
            menuItemChatUnfavorite.Size = new Size(159, 22);
            menuItemChatUnfavorite.Text = "⭐ 즐겨찾기 삭제";
            menuItemChatUnfavorite.Click += menuItemChatUnfavorite_Click;
            //
            // imageList
            //
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            imageList.ImageStream = (ImageListStreamer)resources.GetObject("imageList.ImageStream");
            imageList.TransparentColor = Color.Transparent;
            imageList.Images.SetKeyName(0, "person.png");
            imageList.Images.SetKeyName(1, "chat.png");
            imageList.Images.SetKeyName(2, "setting.png");
            //
            // button_logout
            //
            button_logout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_logout.Location = new Point(790, 20);
            button_logout.Name = "button_logout";
            button_logout.Size = new Size(90, 32);
            button_logout.TabIndex = 1;
            button_logout.Text = "로그아웃";
            button_logout.UseVisualStyleBackColor = true;
            button_logout.Click += button_logout_Click;
            //
            // MainForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(900, 650);
            Controls.Add(button_logout);
            Controls.Add(tabControlChatList);
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimumSize = new Size(600, 500);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DBP Messenger";
            tabControlChatList.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            splitContainerChatList.Panel1.ResumeLayout(false);
            splitContainerChatList.Panel1.PerformLayout();
            splitContainerChatList.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerChatList).EndInit();
            splitContainerChatList.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControlChatList;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ImageList imageList;
        private TabPage tabPage3;
        private SplitContainer splitContainerChatList;
        private ListBox listBoxChats;
        private Label label1;
        private SplitContainer splitContainer1;
        private Label label2;
        private TreeView treeViewEmployee;
        private Button button_logout;
        private TextBox textBoxSearch;
        private ComboBox comboBoxSearchType;
        private Button buttonSearch;
        private Button buttonClearSearch;
        private Label labelSearchResult;
        private Label label3;
        private ContextMenuStrip contextMenuEmployee;
        private ToolStripMenuItem menuItemStartChat;
        private ToolStripMenuItem menuItemAddFavorite;
        private ToolStripMenuItem menuItemRemoveFavorite;
        private ContextMenuStrip contextMenuChatList;
        private ToolStripMenuItem menuItemChatFavorite;
        private ToolStripMenuItem menuItemChatUnfavorite;
    }
}