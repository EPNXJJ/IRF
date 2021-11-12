using Software_Design_Patterns.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Design_Patterns.Entities
{
    public class Ball : Toy
    {
        public SolidBrush BallColor { get; private set; }
        Random rnd = new Random();

        public Ball(Color color)
        {
            BallColor = new SolidBrush(color);
            Click += Ball_Click;
        }

        private void Ball_Click(object sender, EventArgs e)
        {
            Paint += Ball_Paint;
        }

        private void Ball_Paint(object sender, PaintEventArgs e)
        {
            Invalidate();
            RedrawImage(e.Graphics);
        }

        protected override void DrawImage(Graphics g)
        {
            g.FillEllipse(BallColor, 0, 0, Width, Height);
        }

        protected void RedrawImage(Graphics g)
        {
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            g.FillEllipse(new SolidBrush(randomColor), 0, 0, Width, Height);
        }
    }
}
