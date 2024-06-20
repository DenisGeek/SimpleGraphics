using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGraphics.GraphicPrimitives
{
    /// <summary>
    /// <name>Triangle Isosceles </name> <inheritdoc cref="GPBase" path="/summary/name"/>
    /// </summary>
    public class GPTriangleIsosceles : GPBase
    {
        #region Fields and Properties

        /// <summary>
        /// Vertex angle of <inheritdoc cref="GPTriangleIsosceles" path="/summary/name"/>
        /// </summary>
        private double _vertexAngle;

        /// <summary>
        /// Public readonly <inheritdoc cref="_vertexAngle"/>
        /// </summary>
        public double ThisVertexAngle { get => _vertexAngle; }

        /// <summary>
        /// Do draw <inheritdoc cref="_vertexAngle"/> during <see cref="ContainerPaintGraphic"/>
        /// </summary>
        public bool DrawVertexAngle { get; set; } = true;

        #endregion Fields and Properties

        public GPTriangleIsosceles(Control parent, Point location, Size size) : base(parent, location, size) { }

        #region Methods 

        protected override void OnSizeChanged()
        {
            // Calculate Vertex angle
            double tan = ((double)Size.Width / 2) / (double)Size.Height;
            _vertexAngle = Math.Atan(tan) * (180 / Math.PI) * 2;
            _vertexAngle = Math.Round(_vertexAngle, 1);
        }

        public override void ContainerPaintGraphic()
        {
            Graphics g = Graphics.FromImage(_graphicContainer);
            g.Clear(Color.Transparent);

            // Create points that define polygon.
            Point point1 = Point.Add(Location, new(0, Size.Height));
            Point point2 = Point.Add(Location, new(Size.Width / 2, 0));
            Point point3 = Point.Add(Location, new(Size.Width, Size.Height));
            Point[] curvePoints = { point1, point2, point3 };

            // Draw an triangle in the rectangle represented by the control.
            g.FillPolygon(_fillBrush, curvePoints);

            // Draw an triangle in the rectangle represented by the control.
            g.DrawPolygon(_borderPenCurrent, curvePoints);

            // Draw vertex
            if (DrawVertexAngle)
            {
                var text = $"{Math.Round(_vertexAngle, 1)}⁰";
                var font = new Font("Arial", 16);
                SizeF textLen = g.MeasureString(text, font);
                Point textPlace = Point.Add(Location, new(Size.Width / 2 - (int)textLen.Width / 2, Size.Height - (int)textLen.Height - 3));
                g.DrawString(text, font, new SolidBrush(BorderColor), textPlace);
            }
        }

        #endregion Methods 
    }
}
