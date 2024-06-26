﻿using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace SGTestingApp.CustomControls.SimpleGraphicsPrimitives
{
    /// <summary>
    /// Base <inner>simple graphics primitives control</inner>
    /// </summary>
    [ToolboxItem(false)]
    public partial class SGPBase : Control
    {
        #region Fields and Properties

        /// <summary>
        /// <inheritdoc cref="_fillColor"/>
        /// </summary>
        public Color FillColor { get => _fillColor; set { _fillColor = value; _fillBrush = new SolidBrush(value); Invalidate(); } }
        /// <summary>
        /// Fill color for <inheritdoc cref="SGPBase" path="/summary/inner"/>, needs for demonstrte color in editor
        /// </summary>
        private Color _fillColor = Color.Green;
        /// <summary>
        /// Colored brush for <inheritdoc cref="SGPBase" path="/summary/inner"/>, using in OnPaint
        /// </summary>
        protected Brush _fillBrush = Brushes.Green;

        /// <summary>
        /// <inheritdoc cref="_borderColor"/>
        /// </summary>
        public Color BorderColor { get => _borderColor; set { _borderColor = value; _borderPen = new(value); Invalidate(); } }
        /// <summary>
        /// Border color for <inheritdoc cref="SGPBase" path="/summary/inner"/>, needs for demonstrte color in editor
        /// </summary>
        private Color _borderColor = Color.Blue;
        /// <summary>
        /// Colored pen for <inheritdoc cref="SGPBase" path="/summary/inner"/>, using in OnPaint
        /// </summary>
        protected Pen _borderPen = Pens.Blue;

        /// <summary>
        /// <inheritdoc cref="_borderHighlightWidth"/>
        /// </summary>
        public int BorderHighlightWidth { get => _borderHighlightWidth; set { _borderHighlightWidth = value; _borderPenHighlight.Width = value; Invalidate(); } }
        /// <summary>
        /// Border highlight width
        /// </summary>
        private int _borderHighlightWidth = 3;
        /// <summary>
        /// <inheritdoc cref="_borderColorHighlight"/>
        /// </summary>
        public Color BorderHighlightColor
        {
            get => _borderColorHighlight; set
            {
                _borderColorHighlight = value;
                _borderPenHighlight = new(value);
                _borderPenHighlight.Width = _borderHighlightWidth;
                _borderSelectedPenHighlight = GeSelectedtPenHighlight(_borderPenHighlight);

                Invalidate();
            }
        }
        /// <summary>
        /// Border highlight color for <inheritdoc cref="SGPBase" path="/summary/inner"/>, needs for demonstrte color in editor
        /// </summary>
        private Color _borderColorHighlight = Color.Violet;
        /// <summary>
        /// Colored pen for highlight <inheritdoc cref="SGPBase" path="/summary/inner"/>, using in OnPaint
        /// </summary>
        protected Pen _borderPenHighlight = Pens.Violet;

        /// <summary>
        /// Colored pen for highlight selected <inheritdoc cref="SGPBase" path="/summary/inner"/>, using in OnPaint
        /// </summary>
        protected Pen _borderSelectedPenHighlight = Pens.White;

        /// <summary>
        /// border pen, depends on mouse hover
        /// </summary>
        protected Pen _borderPenCurrent = Pens.Blue;

        /// <summary>
        /// Flag abut mouse over the <inheritdoc cref="SGPBase" path="/summary/inner"/>
        /// </summary>
        private bool _isMouseHover = false;

        /// <summary>
        /// Pressed mouse buttons over the <inheritdoc cref="SGPBase" path="/summary/inner"/>
        /// </summary>
        private MouseButtons _mouseButton = MouseButtons.None;

        /// <summary>
        /// initial mouse position when <inheritdoc cref="_mouseButton"/>
        /// </summary>
        private Point _mousePosition = new(0, 0);

        /// <summary>
        /// Flag shows was applied any action with this <inheritdoc cref="SGPBase" path="/summary/inner"/> when mouse moved
        /// </summary>
        private bool _isMouseMoveAction = false;

        #endregion Fields and Properties

        /// <summary>
        /// Constructor, using <see cref="InitializeComponent"/> - <inheritdoc cref="InitializeComponent"/>
        /// </summary>
        public SGPBase()
        {
            InitializeComponent();
        }

        #region Mouse Enter Leave (border Pen Highlight)

        /// <summary>
        /// Change border pen, depends on mouse hover, while <inheritdoc cref="Control.OnPaint"/>
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            // Call the method of the base class.
            base.OnPaint(pe);

            // Highlight border if mouse hover
            _borderPenCurrent = _isMouseHover ? _borderPenHighlight : _borderPen;

            // Highlidht border if selected
            _borderPenCurrent = IsSelectedInParentBox(GetParentBox()) ? _borderSelectedPenHighlight : _borderPenCurrent;
        }

        /// <summary>
        /// Detect moment when mouse enter to control, while <inheritdoc cref="Control.OnMouseEnter"/>
        /// </summary>
        /// <param name="e"><inheritdoc cref="Control.OnMouseEnter" path="/param[@name='e']"/></param>
        protected override void OnMouseEnter(EventArgs e)
        {
            // Call the method of the base class.
            base.OnMouseEnter(e);

            _isMouseHover = true;

            Invalidate();
        }

        /// <summary>
        /// Detect moment when mouse leave control, while <inheritdoc cref="Control.OnMouseLeave"/>
        /// </summary>
        /// <param name="e"><inheritdoc cref="Control.OnMouseLeave" path="/param[@name='e']"/></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            // Call the method of the base class.
            base.OnMouseLeave(e);

            _isMouseHover = false;
            _mouseButton = MouseButtons.None;

            Invalidate();
        }

        #endregion Mouse Enter Leave (border Pen Highlight)

        #region Drag or resize

        /// <summary>
        /// Detect moment when user pressed mouse button over control and take initial mousePosition, while <inheritdoc cref="Control.OnMouseDown"/>
        /// </summary>
        /// <param name="e"><inheritdoc cref="Control.OnMouseDown" path="/param[@name='e']"/></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            // If parent in selection mode then add or remove this from selected items
            var parentBox = GetParentBox();
            if(IsParentInModePrimitivesLinkSelection(parentBox))
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (IsSelectedInParentBox(parentBox))
                    {
                        parentBox!.SelectedPrimitivesRemove(this);
                    }
                    else
                    {
                        parentBox!.SelectedPrimitivesAdd(this);
                    }
                    Invalidate();
                }

                return;
            }

            _mouseButton = e.Button;
            _mousePosition = new(e.X, e.Y);
        }

        /// <summary>
        /// Detect moment when user relse mouse button over control, while <inheritdoc cref="Control.OnMouseUp"/>
        /// </summary>
        /// <param name="e"><inheritdoc cref="Control.OnMouseUp" path="/param[@name='e']"/></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            // Call the method of the base class.
            base.OnMouseUp(e);

            _mouseButton = MouseButtons.None;

            if (_isMouseMoveAction)
            {
                RecreateLinkLines();
                _isMouseMoveAction = false;
            }
        }

        /// <summary>
        /// Drag or resize <inheritdoc cref="SGPBase" path="/summary/inner"/>
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            // Call the method of the base class.
            base.OnMouseMove(e);

            // Drag simple graphics primitives control
            if (_mouseButton == MouseButtons.Left)
            {
                Point mousePositionNew = new(e.X, e.Y);
                Point newLocation = new(Location.X + mousePositionNew.X - _mousePosition.X, Location.Y + mousePositionNew.Y - _mousePosition.Y);

                Location = newLocation;

                // Change linkLine location
                var linkLines = GetAllLineLimks4ThisSGP();
                linkLines.ForEach(x => x.Invalidate());

                _isMouseMoveAction = true;
            }

            // Resize simple graphics primitives control
            if (_mouseButton == MouseButtons.Right)
            {
                Point mousePositionNew = new(e.X, e.Y);

                Height = Height + mousePositionNew.Y - _mousePosition.Y;
                Width = Width + mousePositionNew.X - _mousePosition.X;

                _mousePosition = mousePositionNew;
                Invalidate();

                // Change linkLine location
                var linkLines = GetAllLineLimks4ThisSGP();
                linkLines.ForEach(x => x.Invalidate());

                _isMouseMoveAction = true;
            }
        }

        #endregion Drag or resize

        #region Primitives Link Line

        /// <summary>
        /// Get higlith when selected <inheritdoc cref="SGPBase" path="/summary/inner"/>
        /// </summary>
        /// <param name="basePen">Base pen</param>
        /// <returns><see cref="Pen"/> <typeparamref name="basePen"/>  with different dash style </returns>
        private Pen GeSelectedtPenHighlight(Pen basePen)
        {
            var res = (Pen)basePen.Clone();
            res.DashStyle = DashStyle.DashDot;
            return res;
        }

        /// <summary>
        /// Get parent box if it <see cref="SGControlBox"/>
        /// </summary>
        /// <returns>Parent box or null in case it not <see cref="SGControlBox"/></returns>
        private SGControlBox? GetParentBox()
            => Parent.GetType().IsAssignableFrom(typeof(SGControlBox)) ? (SGControlBox)Parent : null;

        /// <summary>
        /// Checking selected this <inheritdoc cref="SGPBase" path="/summary/inner"/>
        /// </summary>
        /// <param name="parentBox">parent box <see cref="SGControlBox"/></param>
        /// <returns><typeparamref name="true"/> if selected</returns>
        private bool IsSelectedInParentBox(SGControlBox? parentBox)
            => parentBox != null && parentBox!.SelectedPrimitivesCheck(this);

        /// <summary>
        /// Checking parent in <inheritdoc cref="SGControlBox.IsModePrimitivesLinkSelection"/>
        /// </summary>
        /// <param name="parentBox">parent box <see cref="SGControlBox"/></param>
        /// <returns><typeparamref name="true"/> if active</returns>
        private bool IsParentInModePrimitivesLinkSelection(SGControlBox? parentBox)
            => parentBox != null && parentBox!.IsModePrimitivesLinkSelection;

        /// <summary>
        /// <inheritdoc cref="SGControlBox.GetAllLineLimks4ThisSGP"/>
        /// </summary>
        private List<SGPLinkLine> GetAllLineLimks4ThisSGP()
        {
            var parentBox = GetParentBox();

            if(parentBox == null)
            {
                return new List<SGPLinkLine>();
            }

            return parentBox.GetAllLineLimks4ThisSGP(this);
        }

        /// <summary>
        /// <inheritdoc cref="SGControlBox.RecreateLinkLines"/> to this <inheritdoc cref="SGPBase" path="/summary/inner"/>
        /// </summary>
        private void RecreateLinkLines()
        {
            var parent  = GetParentBox();
            if (parent == null) { return; };

            var linkLines = GetAllLineLimks4ThisSGP();
            parent.RecreateLinkLines(linkLines);
        }

        #endregion Primitives Link Line
    }
}
