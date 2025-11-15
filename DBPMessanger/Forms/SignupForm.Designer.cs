namespace DBPMessanger.Forms
{
    partial class SignupForm
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
            label_ID = new Label();
            label_PW = new Label();
            label_name = new Label();
            textBox_ID = new TextBox();
            textBox_PW = new TextBox();
            textBox_name = new TextBox();
            label_nickname = new Label();
            textBox_nickname = new TextBox();
            label_address = new Label();
            textBox_address = new TextBox();
            label_department = new Label();
            comboBox_department = new ComboBox();
            pictureBox_profile = new PictureBox();
            label_pascal_code = new Label();
            textBox_pascalcode = new TextBox();
            button_duplication = new Button();
            button_signup = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox_profile).BeginInit();
            SuspendLayout();
            // 
            // label_ID
            // 
            label_ID.AutoSize = true;
            label_ID.Location = new Point(511, 117);
            label_ID.Name = "label_ID";
            label_ID.Size = new Size(37, 32);
            label_ID.TabIndex = 0;
            label_ID.Text = "ID";
            // 
            // label_PW
            // 
            label_PW.AutoSize = true;
            label_PW.Location = new Point(511, 231);
            label_PW.Name = "label_PW";
            label_PW.Size = new Size(51, 32);
            label_PW.TabIndex = 1;
            label_PW.Text = "PW";
            // 
            // label_name
            // 
            label_name.AutoSize = true;
            label_name.Location = new Point(511, 369);
            label_name.Name = "label_name";
            label_name.Size = new Size(62, 32);
            label_name.TabIndex = 2;
            label_name.Text = "이름";
            // 
            // textBox_ID
            // 
            textBox_ID.Location = new Point(511, 166);
            textBox_ID.Name = "textBox_ID";
            textBox_ID.Size = new Size(200, 39);
            textBox_ID.TabIndex = 3;
            // 
            // textBox_PW
            // 
            textBox_PW.Location = new Point(511, 282);
            textBox_PW.Name = "textBox_PW";
            textBox_PW.Size = new Size(200, 39);
            textBox_PW.TabIndex = 4;
            // 
            // textBox_name
            // 
            textBox_name.Location = new Point(511, 414);
            textBox_name.Name = "textBox_name";
            textBox_name.Size = new Size(200, 39);
            textBox_name.TabIndex = 5;
            // 
            // label_nickname
            // 
            label_nickname.AutoSize = true;
            label_nickname.Location = new Point(511, 496);
            label_nickname.Name = "label_nickname";
            label_nickname.Size = new Size(62, 32);
            label_nickname.TabIndex = 6;
            label_nickname.Text = "별명";
            // 
            // textBox_nickname
            // 
            textBox_nickname.Location = new Point(511, 542);
            textBox_nickname.Name = "textBox_nickname";
            textBox_nickname.Size = new Size(200, 39);
            textBox_nickname.TabIndex = 7;
            // 
            // label_address
            // 
            label_address.AutoSize = true;
            label_address.Location = new Point(511, 609);
            label_address.Name = "label_address";
            label_address.Size = new Size(62, 32);
            label_address.TabIndex = 8;
            label_address.Text = "주소";
            // 
            // textBox_address
            // 
            textBox_address.Location = new Point(511, 644);
            textBox_address.Name = "textBox_address";
            textBox_address.Size = new Size(200, 39);
            textBox_address.TabIndex = 9;
            // 
            // label_department
            // 
            label_department.AutoSize = true;
            label_department.Location = new Point(838, 549);
            label_department.Name = "label_department";
            label_department.Size = new Size(118, 32);
            label_department.TabIndex = 10;
            label_department.Text = "소속 부서";
            // 
            // comboBox_department
            // 
            comboBox_department.FormattingEnabled = true;
            comboBox_department.Items.AddRange(new object[] { "1 부서 ", "2 부서", "3 부서" });
            comboBox_department.Location = new Point(838, 609);
            comboBox_department.Name = "comboBox_department";
            comboBox_department.Size = new Size(242, 40);
            comboBox_department.TabIndex = 11;
            // 
            // pictureBox_profile
            // 
            pictureBox_profile.Location = new Point(977, 130);
            pictureBox_profile.Name = "pictureBox_profile";
            pictureBox_profile.Size = new Size(262, 133);
            pictureBox_profile.TabIndex = 12;
            pictureBox_profile.TabStop = false;
            // 
            // label_pascal_code
            // 
            label_pascal_code.AutoSize = true;
            label_pascal_code.Location = new Point(511, 704);
            label_pascal_code.Name = "label_pascal_code";
            label_pascal_code.Size = new Size(118, 32);
            label_pascal_code.TabIndex = 13;
            label_pascal_code.Text = "우편 번호";
            // 
            // textBox_pascalcode
            // 
            textBox_pascalcode.Location = new Point(511, 748);
            textBox_pascalcode.Name = "textBox_pascalcode";
            textBox_pascalcode.Size = new Size(200, 39);
            textBox_pascalcode.TabIndex = 14;
            // 
            // button_duplication
            // 
            button_duplication.Location = new Point(754, 166);
            button_duplication.Name = "button_duplication";
            button_duplication.Size = new Size(150, 46);
            button_duplication.TabIndex = 15;
            button_duplication.Text = "중복 확인";
            button_duplication.UseVisualStyleBackColor = true;
            // 
            // button_signup
            // 
            button_signup.Location = new Point(1202, 704);
            button_signup.Name = "button_signup";
            button_signup.Size = new Size(209, 99);
            button_signup.TabIndex = 16;
            button_signup.Text = "회원가입";
            button_signup.UseVisualStyleBackColor = true;
            // 
            // SignupForm
            // 
            AutoScaleDimensions = new SizeF(14F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1857, 906);
            Controls.Add(button_signup);
            Controls.Add(button_duplication);
            Controls.Add(textBox_pascalcode);
            Controls.Add(label_pascal_code);
            Controls.Add(pictureBox_profile);
            Controls.Add(comboBox_department);
            Controls.Add(label_department);
            Controls.Add(textBox_address);
            Controls.Add(label_address);
            Controls.Add(textBox_nickname);
            Controls.Add(label_nickname);
            Controls.Add(textBox_name);
            Controls.Add(textBox_PW);
            Controls.Add(textBox_ID);
            Controls.Add(label_name);
            Controls.Add(label_PW);
            Controls.Add(label_ID);
            Name = "SignupForm";
            Text = "SignupForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox_profile).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_ID;
        private Label label_PW;
        private Label label_name;
        private TextBox textBox_ID;
        private TextBox textBox_PW;
        private TextBox textBox_name;
        private Label label_nickname;
        private TextBox textBox_nickname;
        private Label label_address;
        private TextBox textBox_address;
        private Label label_department;
        private ComboBox comboBox_department;
        private PictureBox pictureBox_profile;
        private Label label_pascal_code;
        private TextBox textBox_pascalcode;
        private Button button_duplication;
        private Button button_signup;
    }
}