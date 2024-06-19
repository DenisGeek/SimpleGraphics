using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGTestingApp.CustomControls
{
    public partial class SGControlBox : Panel
    {
        private Point _mouseMoove = new (0,0);

        public SGControlBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            {
                var text = $"X:{_mouseMoove.X} Y:{_mouseMoove.Y}";
                var font = new Font("Arial", 16);
                SizeF textLen = pe.Graphics.MeasureString(text, font);
                Point textPlace = new Point(Width / 2 - (int)textLen.Width / 2, Height - (int)textLen.Height - 3);
                pe.Graphics.DrawString(text, font, new SolidBrush(Color.Blue), textPlace);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);


            _mouseMoove = this.PointToClient(new Point(e.X, e.Y));
            Invalidate();
        }

    }
}
