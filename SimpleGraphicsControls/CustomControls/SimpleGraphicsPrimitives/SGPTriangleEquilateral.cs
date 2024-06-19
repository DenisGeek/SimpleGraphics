using System.Drawing;

namespace SGTestingApp.CustomControls.SimpleGraphicsPrimitives
{
    /// <summary>
    /// <name>Triangle Equilateral</name> <inheritdoc cref="SGPBase" path="/summary/inner"/>
    /// </summary>
    public partial class SGPTriangleEquilateral : SGPBase
    {
        /// <summary>
        /// Side of <inheritdoc cref="SGPTriangleEquilateral" path="/summary/name"/>
        /// </summary>
        private int _side;
        /// <summary>
        /// width = <see cref="_side"/> of <inheritdoc cref="SGPTriangleEquilateral" path="/summary/name"/>
        /// </summary>
        private int _width;
        /// <summary>
        /// height of <inheritdoc cref="SGPTriangleEquilateral" path="/summary/name"/>
        /// </summary>
        private int _height;

        /// <summary>
        /// Public readonly <inheritdoc cref="_side"/>
        /// </summary>
        public int ThisSide { get => _side; }

        /// <summary>
        /// field for <inheritdoc cref="DrawVertexAngle"/>
        /// </summary>
        private bool _drawSide = false;

        /// <summary>
        /// Do draw <inheritdoc cref="_vertexAngle"/> during <see cref="OnPaint"/>
        /// </summary>
        public bool DrawSide { get => _drawSide; set { _drawSide = value; Invalidate(); } }

        /// <summary>
        /// Constructor, using <see cref="InitializeComponent"/> - <inheritdoc cref="InitializeComponent"/>
        /// </summary>
        public SGPTriangleEquilateral()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Calculate <inheritdoc cref="_vertexAngle"/> when <inheritdoc cref="Control.OnResize" path="/summary"/>
        /// </summary>
        /// <param name="e"><inheritdoc cref="Control.OnResize" path="/param[@name='e']"/></param>
        protected override void OnResize(EventArgs e)
        {
            // Call the OnResize method of the base class.
            base.OnResize(e);

            // Calculate side
            double sq = Math.Pow((double)Width / 2, 2) + Math.Pow((double)Height, 2);
            var sideH = Math.Sqrt(sq);

            _side = sideH < Width - 2 ? (int)Math.Truncate(sideH) : Width - 2;
            _height = (int)Math.Truncate(Math.Tan(Math.PI / 3) * _side / 2);
            _width = _side;

            Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            // Call the OnSizeChanged method of the base class.
            base.OnSizeChanged(e);

            // Control edge
            var curvePath = new System.Drawing.Drawing2D.GraphicsPath();


            // Create points that define triangle edge polygon.
            Point point1 = new Point(0, _height - 1);
            Point point2 = new Point(_width / 2 - 2, 0);
            Point point3 = new Point(_width / 2, 0);
            Point point4 = new Point(_width - 1, _height - 1);
            Point[] curvePoints = { point1, point2, point3, point4 };

            // Define control edge
            curvePath.AddPolygon(curvePoints);

            // Set control region
            this.Region = new Region(curvePath);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {

            // Call the OnPaint method of the base class.
            base.OnPaint(pe);


            // Create points that define polygon.
            Point point1 = new Point(1, _height - 2);
            Point point2 = new Point(_width / 2 - 1, 1);
            Point point3 = new Point(_width - 2, _height - 2);
            Point[] curvePoints = { point1, point2, point3 };

            // Draw an triangle in the rectangle represented by the control.
            pe.Graphics.FillPolygon(_fillBrush, curvePoints);

            // Draw an triangle in the rectangle represented by the control.
            pe.Graphics.DrawPolygon(_borderPenCurrent, curvePoints);

            // Draw side
            if (DrawSide)
            {
                var text = $"{_side}";
                var font = new Font("Arial", 16);
                SizeF textLen = pe.Graphics.MeasureString(text, font);
                Point textPlace = new Point(_width / 2 - (int)textLen.Width / 2, _height - (int)textLen.Height - 3);
                pe.Graphics.DrawString(text, font, new SolidBrush(BorderColor), textPlace);
            }
        }
    }
}
