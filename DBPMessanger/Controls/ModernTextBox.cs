using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DBPMessanger.Controls
{
    public class ModernTextBox : Panel
    {
        private TextBox textBox;
        private int borderRadius = 10;
        private Color borderColor = Color.FromArgb(200, 200, 200);
        private Color focusBorderColor = Color.FromArgb(70, 130, 180);
        private bool isFocused = false;

        public int BorderRadius
        {
            get => borderRadius;
            set
            {
                borderRadius = value;
                Invalidate();
            }
        }

        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        public Color FocusBorderColor
        {
            get => focusBorderColor;
            set => focusBorderColor = value;
        }

        public override string Text
        {
            get => textBox.Text;
            set => textBox.Text = value;
        }

        public string PlaceholderText
        {
            get => textBox.PlaceholderText;
            set => textBox.PlaceholderText = value;
        }

        public new Font Font
        {
            get => textBox.Font;
            set => textBox.Font = value;
        }

        public ModernTextBox()
        {
            BackColor = Color.White;
            DoubleBuffered = true;

            textBox = new TextBox
            {
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(10, 8),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };

            textBox.GotFocus += (s, e) =>
            {
                isFocused = true;
                Invalidate();
            };

            textBox.LostFocus += (s, e) =>
            {
                isFocused = false;
                Invalidate();
            };

            Controls.Add(textBox);
            Padding = new Padding(10, 8, 10, 8);
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            if (textBox != null)
            {
                textBox.Width = Width - 20;
                textBox.Height = Height - 16;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            Color currentBorderColor = isFocused ? focusBorderColor : borderColor;

            using (GraphicsPath path = GetRoundedRectanglePath(rect, borderRadius))
            {
                // 배경 그리기
                using (SolidBrush brush = new SolidBrush(BackColor))
                {
                    g.FillPath(brush, path);
                }

                // 테두리 그리기
                using (Pen pen = new Pen(currentBorderColor, isFocused ? 2 : 1))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }

        public void Clear()
        {
            textBox.Clear();
        }

        public event KeyPressEventHandler? TextBoxKeyPress
        {
            add => textBox.KeyPress += value;
            remove => textBox.KeyPress -= value;
        }
    }
}
