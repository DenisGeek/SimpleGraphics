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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SGTestingApp.CustomControls.SimpleGraphicsPrimitives
{
    /// <summary>
    /// <name>Triangle Isosceles</name> <inheritdoc cref="SGPBase" path="/summary/inner"/>
    /// </summary>
    public partial class SGPTriangleIsosceles : SGPBase
    {
        #region Fields

        /// <summary>
        /// Vertex angle of <inheritdoc cref="SGPTriangleIsosceles" path="/summary/name"/>
        /// </summary>
        private double _vertexAngle;

        /// <summary>
        /// Public readonly <inheritdoc cref="_vertexAngle"/>
        /// </summary>
        public double ThisVertexAngle { get => _vertexAngle; }

        /// <summary>
        /// field for <inheritdoc cref="DrawVertexAngle"/>
        /// </summary>
        private bool _drawVertexAngle = false;

        /// <summary>
        /// Do draw <inheritdoc cref="_vertexAngle"/> during <see cref="OnPaint"/>
        /// </summary>
        public bool DrawVertexAngle { get=> _drawVertexAngle; set { _drawVertexAngle = value; Invalidate(); } }

        #endregion Fields

        /// <summary>
        /// Constructor, using <see cref="InitializeComponent"/> - <inheritdoc cref="InitializeComponent"/>
        /// </summary>
        public SGPTriangleIsosceles()
        {
            InitializeComponent();
        }

        #region Methods 

        /// <summary>
        /// Calculate <inheritdoc cref="_vertexAngle"/> when <inheritdoc cref="Control.OnResize" path="/summary"/>
        /// </summary>
        /// <param name="e"><inheritdoc cref="Control.OnResize" path="/param[@name='e']"/></param>
        protected override void OnResize(EventArgs e)
        {
            // Call the OnResize method of the base class.
            base.OnResize(e);

            // Calculate Vertex angle
            double tan = ((double)Width / 2) / (double)Height;
            _vertexAngle = Math.Atan(tan) * (180 / Math.PI) * 2;
            _vertexAngle = Math.Round(_vertexAngle, 1);

            Invalidate();
        }

        /// <summary>
        /// Set custom control Region, when <inheritdoc cref="Control.OnSizeChanged" path="/summary"/>
        /// <list type="bullet">
        ///   <item>Прозрачная панель в WinForms <see href="https://ru.stackoverflow.com/questions/484198/%D0%9F%D1%80%D0%BE%D0%B7%D1%80%D0%B0%D1%87%D0%BD%D0%B0%D1%8F-%D0%BF%D0%B0%D0%BD%D0%B5%D0%BB%D1%8C-%D0%B2-winforms"/></item>
        ///   <item><see cref="Control.Region "/> <see href="https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.control.region?view=windowsdesktop-8.0"/></item>
        /// </list>
        /// </summary>
        /// <param name="e"><inheritdoc cref="Control.OnSizeChanged" path="/param[@name='e']"/></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            // Call the OnSizeChanged method of the base class.
            base.OnSizeChanged(e);

            // Control edge
            var curvePath = new System.Drawing.Drawing2D.GraphicsPath();

            // Create points that define triangle edge polygon.
            Point point1 = new Point(0, Height - 1);
            Point point2 = new Point(Width / 2 - 2, 0);
            Point point3 = new Point(Width / 2, 0);
            Point point4 = new Point(Width - 1, Height - 1);
            Point[] curvePoints = { point1, point2, point3, point4 };

            // Define control edge
            curvePath.AddPolygon(curvePoints);

            // Set control region
            this.Region = new Region(curvePath);
        }

        /// <summary>
        /// <inheritdoc cref="SGPTriangleIsosceles"/> fill and draw, when <inheritdoc cref="Control.OnPaint" path="/summary"/>
        /// </summary>
        /// <param name="pe"><inheritdoc cref="Control.OnPaint" path="/param[@name='e']"/></param>
        protected override void OnPaint(PaintEventArgs pe)
        {

            // Call the OnPaint method of the base class.
            base.OnPaint(pe);

            // Create points that define polygon.
            Point point1 = new Point(1, Height - 2);
            Point point2 = new Point(Width / 2 - 1, 1);
            Point point3 = new Point(Width - 2, Height - 2);
            Point[] curvePoints = { point1, point2, point3 };

            // Draw an triangle in the rectangle represented by the control.
            pe.Graphics.FillPolygon(_fillBrush, curvePoints);

            // Draw an triangle in the rectangle represented by the control.
            pe.Graphics.DrawPolygon(_borderPenCurrent, curvePoints);

            // Draw vertex
            if (DrawVertexAngle)
            {
                var text = $"{Math.Round(_vertexAngle, 1)}⁰";
                var font = new Font("Arial", 16);
                SizeF textLen = pe.Graphics.MeasureString(text, font);
                Point textPlace = new Point(Width / 2 - (int)textLen.Width / 2, Height - (int)textLen.Height - 3);
                pe.Graphics.DrawString(text, font, new SolidBrush(BorderColor), textPlace);
            }

        }

        #endregion Methods 
    }
}
