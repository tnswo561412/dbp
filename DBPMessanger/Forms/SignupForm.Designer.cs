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
            label_zip_code = new Label();
            textBox_pascalcode = new TextBox();
            button_duplication = new Button();
            button_signup = new Button();
            label_birthday = new Label();
            textBox_birthday = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox_profile).BeginInit();
            SuspendLayout();
            // 
            // label_ID
            // 
            label_ID.AutoSize = true;
            label_ID.Location = new Point(77, 24);
            label_ID.Margin = new Padding(2, 0, 2, 0);
            label_ID.Name = "label_ID";
            label_ID.Size = new Size(19, 15);
            label_ID.TabIndex = 0;
            label_ID.Text = "ID";
            // 
            // label_PW
            // 
            label_PW.AutoSize = true;
            label_PW.Location = new Point(77, 85);
            label_PW.Margin = new Padding(2, 0, 2, 0);
            label_PW.Name = "label_PW";
            label_PW.Size = new Size(25, 15);
            label_PW.TabIndex = 1;
            label_PW.Text = "PW";
            // 
            // label_name
            // 
            label_name.AutoSize = true;
            label_name.Location = new Point(77, 154);
            label_name.Margin = new Padding(2, 0, 2, 0);
            label_name.Name = "label_name";
            label_name.Size = new Size(31, 15);
            label_name.TabIndex = 2;
            label_name.Text = "이름";
            // 
            // textBox_ID
            // 
            textBox_ID.Location = new Point(77, 40);
            textBox_ID.Margin = new Padding(2, 1, 2, 1);
            textBox_ID.Name = "textBox_ID";
            textBox_ID.Size = new Size(102, 23);
            textBox_ID.TabIndex = 3;
            // 
            // textBox_PW
            // 
            textBox_PW.Location = new Point(77, 101);
            textBox_PW.Margin = new Padding(2, 1, 2, 1);
            textBox_PW.Name = "textBox_PW";
            textBox_PW.Size = new Size(102, 23);
            textBox_PW.TabIndex = 4;
            // 
            // textBox_name
            // 
            textBox_name.Location = new Point(77, 170);
            textBox_name.Margin = new Padding(2, 1, 2, 1);
            textBox_name.Name = "textBox_name";
            textBox_name.Size = new Size(102, 23);
            textBox_name.TabIndex = 5;
            // 
            // label_nickname
            // 
            label_nickname.AutoSize = true;
            label_nickname.Location = new Point(77, 218);
            label_nickname.Margin = new Padding(2, 0, 2, 0);
            label_nickname.Name = "label_nickname";
            label_nickname.Size = new Size(31, 15);
            label_nickname.TabIndex = 6;
            label_nickname.Text = "별명";
            label_nickname.Click += label_nickname_Click;
            // 
            // textBox_nickname
            // 
            textBox_nickname.Location = new Point(77, 234);
            textBox_nickname.Margin = new Padding(2, 1, 2, 1);
            textBox_nickname.Name = "textBox_nickname";
            textBox_nickname.Size = new Size(102, 23);
            textBox_nickname.TabIndex = 7;
            // 
            // label_address
            // 
            label_address.AutoSize = true;
            label_address.Location = new Point(77, 285);
            label_address.Margin = new Padding(2, 0, 2, 0);
            label_address.Name = "label_address";
            label_address.Size = new Size(31, 15);
            label_address.TabIndex = 8;
            label_address.Text = "주소";
            // 
            // textBox_address
            // 
            textBox_address.Location = new Point(77, 301);
            textBox_address.Margin = new Padding(2, 1, 2, 1);
            textBox_address.Name = "textBox_address";
            textBox_address.Size = new Size(102, 23);
            textBox_address.TabIndex = 9;
            // 
            // label_department
            // 
            label_department.AutoSize = true;
            label_department.Location = new Point(298, 85);
            label_department.Margin = new Padding(2, 0, 2, 0);
            label_department.Name = "label_department";
            label_department.Size = new Size(59, 15);
            label_department.TabIndex = 10;
            label_department.Text = "소속 부서";
            // 
            // comboBox_department
            // 
            comboBox_department.FormattingEnabled = true;
            comboBox_department.Items.AddRange(new object[] { "개발", "디자인" });
            comboBox_department.Location = new Point(298, 101);
            comboBox_department.Margin = new Padding(2, 1, 2, 1);
            comboBox_department.Name = "comboBox_department";
            comboBox_department.Size = new Size(123, 23);
            comboBox_department.TabIndex = 11;
            // 
            // pictureBox_profile
            // 
            pictureBox_profile.Location = new Point(583, 24);
            pictureBox_profile.Margin = new Padding(2, 1, 2, 1);
            pictureBox_profile.Name = "pictureBox_profile";
            pictureBox_profile.Size = new Size(131, 242);
            pictureBox_profile.TabIndex = 12;
            pictureBox_profile.TabStop = false;
            // 
            // label_zip_code
            // 
            label_zip_code.AutoSize = true;
            label_zip_code.Location = new Point(77, 351);
            label_zip_code.Margin = new Padding(2, 0, 2, 0);
            label_zip_code.Name = "label_zip_code";
            label_zip_code.Size = new Size(59, 15);
            label_zip_code.TabIndex = 13;
            label_zip_code.Text = "우편 번호";
            // 
            // textBox_pascalcode
            // 
            textBox_pascalcode.Location = new Point(77, 367);
            textBox_pascalcode.Margin = new Padding(2, 1, 2, 1);
            textBox_pascalcode.Name = "textBox_pascalcode";
            textBox_pascalcode.Size = new Size(102, 23);
            textBox_pascalcode.TabIndex = 14;
            // 
            // button_duplication
            // 
            button_duplication.Location = new Point(195, 41);
            button_duplication.Margin = new Padding(2, 1, 2, 1);
            button_duplication.Name = "button_duplication";
            button_duplication.Size = new Size(75, 22);
            button_duplication.TabIndex = 15;
            button_duplication.Text = "중복 확인";
            button_duplication.UseVisualStyleBackColor = true;
            // 
            // button_signup
            // 
            button_signup.Location = new Point(796, 354);
            button_signup.Margin = new Padding(2, 1, 2, 1);
            button_signup.Name = "button_signup";
            button_signup.Size = new Size(104, 46);
            button_signup.TabIndex = 16;
            button_signup.Text = "회원가입";
            button_signup.UseVisualStyleBackColor = true;
            // 
            // label_birthday
            // 
            label_birthday.AutoSize = true;
            label_birthday.Location = new Point(298, 24);
            label_birthday.Name = "label_birthday";
            label_birthday.Size = new Size(31, 15);
            label_birthday.TabIndex = 17;
            label_birthday.Text = "생일";
            // 
            // textBox_birthday
            // 
            textBox_birthday.Location = new Point(298, 41);
            textBox_birthday.Name = "textBox_birthday";
            textBox_birthday.Size = new Size(100, 23);
            textBox_birthday.TabIndex = 18;
            // 
            // SignupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(928, 425);
            Controls.Add(textBox_birthday);
            Controls.Add(label_birthday);
            Controls.Add(button_signup);
            Controls.Add(button_duplication);
            Controls.Add(textBox_pascalcode);
            Controls.Add(label_zip_code);
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
            Margin = new Padding(2, 1, 2, 1);
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
        private Label label_zip_code;
        private TextBox textBox_pascalcode;
        private Button button_duplication;
        private Button button_signup;
        private Label label_birthday;
        private TextBox textBox_birthday;
    }
}