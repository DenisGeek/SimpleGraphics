using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGraphics.GraphicPrimitives
{
    /// <summary>
    /// <name>Circle </name> <inheritdoc cref="GPBase" path="/summary/name"/>
    /// </summary>
    public class GPCircle : GPBase
    {
        #region Fields and Properties

        /// <summary>
        /// Circle radius
        /// </summary>
        private int _radius;

        /// <summary>
        /// Public readonly <inheritdoc cref="_radius"/>
        /// </summary>
        public int Radius { get => _radius; }

        #endregion Fields and Properties

        public GPCircle(Control parent, Point location, Size size) : base(parent, location, size) { }

        #region Methods

        protected override void OnSizeChanged()
            => _radius = Size.Height < Size.Width ? Size.Height / 2 : Size.Width / 2;

        public override void ContainerPaintGraphic()
        {
            Graphics g = Graphics.FromImage(_graphicContainer);
            g.Clear(Color.Transparent);

            // Create a circle that represents the size of the control, minus 1 pixel.
            var area = new Rectangle(Location, new Size(_radius * 2, _radius * 2));

            // Fill an triangle in the rectangle represented by the control.
            g.FillEllipse(_fillBrush, area);

            // Draw an triangle in the rectangle represented by the control.
            g.DrawEllipse(_borderPenCurrent, area);
        }

        #endregion Methods
    }
}
