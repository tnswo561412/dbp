namespace DBPMessanger.Forms
{
    partial class LoginForm
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
            textBox_ID = new TextBox();
            button_login = new Button();
            button1 = new Button();
            label_ID = new Label();
            label_PW = new Label();
            textBox1 = new TextBox();
            checkBox_auto_ID_PW = new CheckBox();
            checkBox_auto_login = new CheckBox();
            SuspendLayout();
            // 
            // textBox_ID
            // 
            textBox_ID.Location = new Point(459, 187);
            textBox_ID.Margin = new Padding(6, 6, 6, 6);
            textBox_ID.Name = "textBox_ID";
            textBox_ID.Size = new Size(438, 39);
            textBox_ID.TabIndex = 0;
            // 
            // button_login
            // 
            button_login.Location = new Point(459, 488);
            button_login.Margin = new Padding(6, 6, 6, 6);
            button_login.Name = "button_login";
            button_login.Size = new Size(150, 49);
            button_login.TabIndex = 1;
            button_login.Text = "로그인";
            button_login.UseVisualStyleBackColor = true;
            button_login.Click += button1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(747, 491);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 2;
            button1.Text = "회원가입";
            button1.UseVisualStyleBackColor = true;
            // 
            // label_ID
            // 
            label_ID.AutoSize = true;
            label_ID.Location = new Point(459, 133);
            label_ID.Name = "label_ID";
            label_ID.Size = new Size(37, 32);
            label_ID.TabIndex = 3;
            label_ID.Text = "ID";
            // 
            // label_PW
            // 
            label_PW.AutoSize = true;
            label_PW.Location = new Point(459, 257);
            label_PW.Name = "label_PW";
            label_PW.Size = new Size(51, 32);
            label_PW.TabIndex = 4;
            label_PW.Text = "PW";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(460, 318);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(437, 39);
            textBox1.TabIndex = 5;
            // 
            // checkBox_auto_ID_PW
            // 
            checkBox_auto_ID_PW.AutoSize = true;
            checkBox_auto_ID_PW.Location = new Point(460, 406);
            checkBox_auto_ID_PW.Name = "checkBox_auto_ID_PW";
            checkBox_auto_ID_PW.Size = new Size(226, 36);
            checkBox_auto_ID_PW.TabIndex = 6;
            checkBox_auto_ID_PW.Text = "ID PW 자동 입력";
            checkBox_auto_ID_PW.UseVisualStyleBackColor = true;
            // 
            // checkBox_auto_login
            // 
            checkBox_auto_login.AutoSize = true;
            checkBox_auto_login.Location = new Point(747, 406);
            checkBox_auto_login.Name = "checkBox_auto_login";
            checkBox_auto_login.Size = new Size(174, 36);
            checkBox_auto_login.TabIndex = 7;
            checkBox_auto_login.Text = "자동 로그인";
            checkBox_auto_login.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(14F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 960);
            Controls.Add(checkBox_auto_login);
            Controls.Add(checkBox_auto_ID_PW);
            Controls.Add(textBox1);
            Controls.Add(label_PW);
            Controls.Add(label_ID);
            Controls.Add(button1);
            Controls.Add(button_login);
            Controls.Add(textBox_ID);
            Margin = new Padding(6, 6, 6, 6);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_ID;
        private Button button_login;
        private Button button1;
        private Label label_ID;
        private Label label_PW;
        private TextBox textBox1;
        private CheckBox checkBox_auto_ID_PW;
        private CheckBox checkBox_auto_login;
    }
}