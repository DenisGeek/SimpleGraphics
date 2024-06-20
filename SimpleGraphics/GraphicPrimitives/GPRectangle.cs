using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGraphics.GraphicPrimitives
{
    public class GPRectangle : GPBase
    {
        public GPRectangle(Control parent, Point location, Size size) : base(parent, location, size) { }

        #region Methods 

        public override void ContainerPaintGraphic()
        {
            Graphics g = Graphics.FromImage(_graphicContainer);
            g.Clear(Color.Transparent);

            // Create a rectangle that represents the size of the control, minus 1 pixel.
            var area = new Rectangle(Location, Size);

            // Draw an rectangle in the rectangle represented by the control.
            g.FillRectangle(_fillBrush, area);

            // Draw an rectangle in the rectangle represented by the control.
            g.DrawRectangle(_borderPenCurrent, area);
        }

        #endregion Methods 
    }
}
