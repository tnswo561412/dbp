using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBPMessanger.Controls
{
    public partial class ChatControl : UserControl
    {
        private string? name;
        private string? message;
        private bool? isMine;
        private Image? profilePic;

        public ChatControl()
        {
            InitializeComponent();
        }

        public ChatControl(string name, string message, DateTime dateTime ,bool isMine, Image profilePic, int width)
        {
            InitializeComponent();

            this.name = name;
            this.message = message;
            this.isMine = isMine;
            this.profilePic = profilePic;

            labelName.Text = name;
            labelMessage.Text = message;
            labelTime.Text = dateTime.ToString("HH:mm");
            pictureBox1.Image = profilePic;

            labelMessage.MaximumSize = new Size((int)(width * 0.8 - 50), 0);

            Dock = DockStyle.Top;

            if (isMine)
            {
                tableLayoutPanel1.RowStyles[0].Height = 0;
                tableLayoutPanel1.ColumnStyles[0].Width = 0;
                RightToLeft = RightToLeft.Yes;

                labelMessage.Anchor = AnchorStyles.Right;
                labelMessage.TextAlign = ContentAlignment.BottomRight;
            }
            else
            {
                labelMessage.BackColor = Color.White;
            }
        }
    }
}
