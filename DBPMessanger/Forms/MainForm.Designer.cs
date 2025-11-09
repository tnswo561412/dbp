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
            treeViewEmployee = new TreeView();
            tabPage2 = new TabPage();
            splitContainerChatList = new SplitContainer();
            label1 = new Label();
            listBoxChats = new ListBox();
            tabPage3 = new TabPage();
            imageList = new ImageList(components);
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
            tabControlChatList.Controls.Add(tabPage1);
            tabControlChatList.Controls.Add(tabPage2);
            tabControlChatList.Controls.Add(tabPage3);
            tabControlChatList.ImageList = imageList;
            tabControlChatList.ItemSize = new Size(50, 50);
            tabControlChatList.Location = new Point(0, 0);
            tabControlChatList.Multiline = true;
            tabControlChatList.Name = "tabControlChatList";
            tabControlChatList.Padding = new Point(15, 3);
            tabControlChatList.SelectedIndex = 0;
            tabControlChatList.Size = new Size(383, 592);
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
            splitContainer1.Panel1.Controls.Add(label2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(treeViewEmployee);
            splitContainer1.Size = new Size(319, 578);
            splitContainer1.SplitterDistance = 94;
            splitContainer1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 20F);
            label2.Location = new Point(12, 28);
            label2.Name = "label2";
            label2.Size = new Size(71, 37);
            label2.TabIndex = 0;
            label2.Text = "직원";
            // 
            // treeViewEmployee
            // 
            treeViewEmployee.Location = new Point(3, 3);
            treeViewEmployee.Name = "treeViewEmployee";
            treeViewEmployee.Size = new Size(313, 465);
            treeViewEmployee.TabIndex = 0;
            treeViewEmployee.NodeMouseDoubleClick += TreeView1_NodeMouseDoubleClick;
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
            listBoxChats.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxChats.FormattingEnabled = true;
            listBoxChats.ItemHeight = 60;
            listBoxChats.Location = new Point(0, 3);
            listBoxChats.Name = "listBoxChats";
            listBoxChats.Size = new Size(325, 484);
            listBoxChats.TabIndex = 3;
            listBoxChats.DrawItem += listBoxChats_DrawItem;
            listBoxChats.SelectedIndexChanged += listBoxChats_SelectedIndexChanged;
            // 
            // tabPage3
            // 
            tabPage3.ImageIndex = 2;
            tabPage3.Location = new Point(54, 4);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(325, 584);
            tabPage3.TabIndex = 2;
            tabPage3.UseVisualStyleBackColor = true;
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 591);
            Controls.Add(tabControlChatList);
            Name = "MainForm";
            Text = "MainForm";
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
    }
}