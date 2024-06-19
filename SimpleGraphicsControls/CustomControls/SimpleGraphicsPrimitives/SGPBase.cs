using System.Windows.Forms;

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

        public int BorderHighlightWidth { get => _borderHighlightWidth; set { _borderHighlightWidth = value; _borderPenHighlight.Width = value; Invalidate(); } }
        private int _borderHighlightWidth = 3;
        public Color BorderHighlightColor { get => _borderColorHighlight; set { _borderColorHighlight = value; _borderPenHighlight = new(value);  Invalidate(); } }
        private Color _borderColorHighlight = Color.Violet;
        protected Pen _borderPenHighlight = Pens.Violet;

        protected Pen _borderPenCurrent = Pens.Blue;

        protected bool _isMouseHover = false;
        protected bool _isDrag = false;
        protected bool _isResize = false;

        protected MouseButtons _mouseButton = MouseButtons.None;
        protected Point _mousePosition = new (0,0);

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
            _borderPenCurrent = _isMouseHover ? _borderPenHighlight : _borderPen;
            if (_isMouseHover)

                base.OnPaint(pe);
        }

        #region Mouse Enter Leave

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnEnter(e);

            _isMouseHover = true;

            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnLeave(e);

            _isMouseHover = false;
            _mouseButton = MouseButtons.None;

            Invalidate();
        }

        #endregion Mouse Enter Leave


        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            _mouseButton = e.Button;
            _mousePosition = new (e.X, e.Y);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            _mouseButton = MouseButtons.None;

            //_ = e.Button switch
            //{
            //    MouseButtons.Left => _isDrag = false,
            //    MouseButtons.Right => _isResize = false,
            //    _ => false,
            //};
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            Point mousePositionNew = new(e.X, e.Y);

            if (_mouseButton == MouseButtons.Left)
            {
                Point newLocation = new(Location.X + mousePositionNew.X - _mousePosition.X, Location.Y + mousePositionNew.Y - _mousePosition.Y);
                Location = newLocation;
            }

            if (_mouseButton == MouseButtons.Right)
            {
                Height = Height + mousePositionNew.Y - _mousePosition.Y;
                Width = Width + mousePositionNew.X - _mousePosition.X;

                _mousePosition = mousePositionNew;
                Invalidate();
            }
        }
    }
}
