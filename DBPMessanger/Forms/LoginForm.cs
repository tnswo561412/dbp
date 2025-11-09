using DBPMessanger.infos;
using DBPMessanger.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBPMessanger.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            int i = int.Parse(text);

            // 임시 데이터 로그인 시에 받아올 유저정보
            UserInfo? info = DBManager.Instance.Query<UserInfo>(
                q => q.Where(u => u.Id == i))
                .FirstOrDefault();
            OwnerUserManager.Instance.initOwerUser(info);

            _ = WebSocketManager.Instance.Connect(Constants.Server, i);

            var form = new MainForm();
            form.Show();
        }
    }
}
