namespace DBPMessanger.Forms
{
    partial class ChatForm
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
            splitContainerChat = new SplitContainer();
            panelChat = new Panel();
            labelDepartment = new Label();
            labelName = new Label();
            pictureBox1 = new PictureBox();
            buttonSend = new Button();
            richTextBoxChat = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainerChat).BeginInit();
            splitContainerChat.Panel1.SuspendLayout();
            splitContainerChat.Panel2.SuspendLayout();
            splitContainerChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // splitContainerChat
            // 
            splitContainerChat.IsSplitterFixed = true;
            splitContainerChat.Location = new Point(0, 0);
            splitContainerChat.Name = "splitContainerChat";
            splitContainerChat.Orientation = Orientation.Horizontal;
            // 
            // splitContainerChat.Panel1
            // 
            splitContainerChat.Panel1.BackColor = Color.White;
            splitContainerChat.Panel1.Controls.Add(panelChat);
            splitContainerChat.Panel1.Controls.Add(labelDepartment);
            splitContainerChat.Panel1.Controls.Add(labelName);
            splitContainerChat.Panel1.Controls.Add(pictureBox1);
            // 
            // splitContainerChat.Panel2
            // 
            splitContainerChat.Panel2.Controls.Add(buttonSend);
            splitContainerChat.Panel2.Controls.Add(richTextBoxChat);
            splitContainerChat.Size = new Size(371, 606);
            splitContainerChat.SplitterDistance = 489;
            splitContainerChat.TabIndex = 0;
            // 
            // panelChat
            // 
            panelChat.AutoScroll = true;
            panelChat.BackColor = Color.SkyBlue;
            panelChat.ForeColor = Color.Black;
            panelChat.Location = new Point(3, 77);
            panelChat.Name = "panelChat";
            panelChat.Size = new Size(365, 413);
            panelChat.TabIndex = 4;
            // 
            // labelDepartment
            // 
            labelDepartment.AutoSize = true;
            labelDepartment.Location = new Point(70, 47);
            labelDepartment.Name = "labelDepartment";
            labelDepartment.Size = new Size(95, 15);
            labelDepartment.TabIndex = 3;
            labelDepartment.Text = "개발부서 개발팀";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("맑은 고딕", 15F);
            labelName.Location = new Point(68, 12);
            labelName.Name = "labelName";
            labelName.Size = new Size(72, 28);
            labelName.TabIndex = 2;
            labelName.Text = "홍길동";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // buttonSend
            // 
            buttonSend.Location = new Point(293, 87);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(75, 23);
            buttonSend.TabIndex = 1;
            buttonSend.Text = "전송";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += buttonSend_Click;
            // 
            // richTextBoxChat
            // 
            richTextBoxChat.Location = new Point(0, 3);
            richTextBoxChat.Name = "richTextBoxChat";
            richTextBoxChat.Size = new Size(368, 80);
            richTextBoxChat.TabIndex = 0;
            richTextBoxChat.Text = "";
            richTextBoxChat.KeyDown += richTextBoxChat_KeyDown;
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(371, 606);
            Controls.Add(splitContainerChat);
            Name = "ChatForm";
            Text = "ChatForm";
            FormClosed += ChatForm_FormClosed;
            splitContainerChat.Panel1.ResumeLayout(false);
            splitContainerChat.Panel1.PerformLayout();
            splitContainerChat.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerChat).EndInit();
            splitContainerChat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainerChat;
        private Button buttonSend;
        private RichTextBox richTextBoxChat;
        private Label labelDepartment;
        private Label labelName;
        private PictureBox pictureBox1;
        private Panel panelChat;
    }
}