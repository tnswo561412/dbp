using DBPMessanger.infos;
using DBPMessanger.Config;
using Microsoft.EntityFrameworkCore;

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
    public partial class SignupForm : Form
    {
        private readonly AppDBContext db;
        public UserInfo? LoggedInUser { get; private set; }


        public SignupForm()
        {
            InitializeComponent();
            db = new AppDBContext();
        }

        private void label_nickname_Click(object sender, EventArgs e)
        {

        }
    }
}
