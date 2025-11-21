using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DBPMessanger.Controls
{
    public class RoundedButton : Button
    {
        private int borderRadius = 10;
        private Color hoverBackColor = Color.FromArgb(100, 100, 100);
        private Color pressedBackColor = Color.FromArgb(80, 80, 80);
        private bool isHovering = false;
        private bool isPressed = false;

        public int BorderRadius
        {
            get => borderRadius;
            set
            {
                borderRadius = value;
                Invalidate();
            }
        }

        public Color HoverBackColor
        {
            get => hoverBackColor;
            set => hoverBackColor = value;
        }

        public Color PressedBackColor
        {
            get => pressedBackColor;
            set => pressedBackColor = value;
        }

        public RoundedButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.FromArgb(70, 130, 180);
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            Cursor = Cursors.Hand;
            Padding = new Padding(10, 5, 10, 5);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            isHovering = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isHovering = false;
            isPressed = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            isPressed = true;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            isPressed = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // 배경색 결정
            Color currentBackColor = BackColor;
            if (isPressed)
                currentBackColor = pressedBackColor;
            else if (isHovering)
                currentBackColor = hoverBackColor;

            // 둥근 사각형 그리기
            using (GraphicsPath path = GetRoundedRectanglePath(ClientRectangle, borderRadius))
            {
                using (SolidBrush brush = new SolidBrush(currentBackColor))
                {
                    g.FillPath(brush, path);
                }
            }

            // 텍스트 그리기
            TextRenderer.DrawText(g, Text, Font, ClientRectangle, ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
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
    }
}
