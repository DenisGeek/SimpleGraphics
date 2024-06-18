namespace SGTestingApp.CustomControls.SimpleGraphicsPrimitives
{
    /// <summary>
    /// Base <inner>simple graphics primitives control</inner>
    /// </summary>
    public partial class SGPBase : Control
    {
        //public Color FillColor { get => _fillColor; set { _fillColor = value; _fillBrush = new SolidBrush(Color.FromArgb(0, value)); Invalidate(); } }
        public Color FillColor { get => _fillColor; set { _fillColor = value; _fillBrush = new SolidBrush(value); Invalidate(); } }
        private Color _fillColor = Color.Green;
        protected Brush _fillBrush = Brushes.Green;

        public Color BorderColor { get => _borderColor; set { _borderColor = value; _borderPen = new (value); Invalidate(); } }
        private Color _borderColor = Color.Blue;
        protected Pen _borderPen = Pens.Blue;

        public SGPBase()
        {
            InitializeComponent();
        }

        //protected override void OnPaintBackground(PaintEventArgs pe)
        //{
        //    var transparentColor = Color.FromArgb(0, this.BackColor);
        //    //pe.Graphics.Clear(transparentColor);

        //    var transparentBruch = new SolidBrush(transparentColor);
            
        //    // Create a rectangle that represents the size of the control, minus 1 pixel.
        //    var area = new Rectangle(new Point(0, 0), new Size(this.Size.Width - 1, this.Size.Height - 1));

        //    // Draw an rectangle in the rectangle represented by the control.
        //    pe.Graphics.FillRectangle(transparentBruch, area);
        //}

        protected override void OnPaint(PaintEventArgs pe)
        {

            base.OnPaint(pe);
        }
    }
}
