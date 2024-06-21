using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGraphics.GraphicPrimitives
{
    /// <summary>
    /// <name>Triangle Equilateral </name> <inheritdoc cref="GPBase" path="/summary/name"/>
    /// </summary>
    public class GPTriangleEquilateral : GPBase
    {
        #region Fields and Properties

        /// <summary>
        /// Side of <inheritdoc cref="GPTriangleEquilateral" path="/summary/name"/>
        /// </summary>
        private int _side;
        /// <summary>
        /// width = <see cref="_side"/> of <inheritdoc cref="GPTriangleEquilateral" path="/summary/name"/>
        /// </summary>
        private int _width;
        /// <summary>
        /// height of <inheritdoc cref="GPTriangleEquilateral" path="/summary/name"/>
        /// </summary>
        private int _height;

        /// <summary>
        /// Public readonly <inheritdoc cref="_side"/>
        /// </summary>
        public int Side { get => _side; }

        /// <summary>
        /// Do draw <inheritdoc cref="_side"/> during <see cref="PaintGraphic"/>
        /// </summary>
        public bool DrawSide { get; set; } = true;

        #endregion Fields and Properties

        public GPTriangleEquilateral(Control parent, Point location, Size size) : base(parent, location, size) { }

        #region Methods 

        protected override void OnSizeChanged()
        {
            _side = Size.Height < Size.Width ? Size.Height : Size.Width;
            _height = (int)Math.Truncate(Math.Tan(Math.PI / 3) * _side / 2);
            _width = _side;
        }

        protected override void PaintGraphicInternal(ref Bitmap container, Color colorClean)
        {
            Graphics g = Graphics.FromImage(container);
            g.Clear(colorClean);

            // Create points that define polygon.
            Point point1 = Point.Add(Location, new(0, _height));
            Point point2 = Point.Add(Location, new(_width / 2, 0));
            Point point3 = Point.Add(Location, new(_width, _height));
            Point[] curvePoints = { point1, point2, point3 };

            // Draw an triangle in the rectangle represented by the control.
            g.FillPolygon(_fillBrush, curvePoints);

            // Draw an triangle in the rectangle represented by the control.
            g.DrawPolygon(_borderPenCurrent, curvePoints);

            // Draw side
            if (DrawSide)
            {
                var text = $"{_side}";
                var font = new Font("Arial", 16);
                SizeF textLen = g.MeasureString(text, font);
                Point textPlace = Point.Add(Location, new(_width / 2 - (int)textLen.Width / 2, _height - (int)textLen.Height - 3));
                g.DrawString(text, font, new SolidBrush(BorderColor), textPlace);
            }
        }

        #endregion Methods 
    }
}
