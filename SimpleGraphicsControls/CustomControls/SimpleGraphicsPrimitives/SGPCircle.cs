using System.ComponentModel;

namespace SGTestingApp.CustomControls.SimpleGraphicsPrimitives
{
    /// <summary>
    /// Circle <inheritdoc cref="SGPBase" path="/summary/inner"/>
    /// </summary>
    [ToolboxItem(true)]
    public partial class SGPCircle : SGPBase
    {
        #region Fields and Properties

        /// <summary>
        /// Circle radius
        /// </summary>
        private int _radius;

        /// <summary>
        /// Public readonly <inheritdoc cref="_radius"/>
        /// </summary>
        public int ThisRadius { get => _radius; }

        #endregion Fields and Properties

        /// <summary>
        /// Constructor, using <see cref="InitializeComponent"/> - <inheritdoc cref="InitializeComponent"/>
        /// </summary>
        public SGPCircle()
        {
            InitializeComponent();
        }

        #region Methods

        /// <summary>
        /// Calculate circle radius when <inheritdoc cref="Control.OnResize" path="/summary"/>
        /// </summary>
        /// <param name="e"><inheritdoc cref="Control.OnResize" path="/param[@name='e']"/></param>
        protected override void OnResize(EventArgs e)
        {
            // Call the OnResize method of the base class.
            base.OnResize(e);

            // Calculate circle radius
            _radius = Height < Width ? Height / 2 : Width / 2;
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

            // Create points that define polygon.
            var area = new Rectangle(new Point(0, 0), new Size(_radius * 2 - 1, _radius * 2 - 1));

            // Define control edge
            curvePath.AddEllipse(area);

            // Set control region
            this.Region = new Region(curvePath);
        }

        /// <summary>
        /// <inheritdoc cref="SGPCircle"/> fill and draw, when <inheritdoc cref="Control.OnPaint" path="/summary"/>
        /// </summary>
        /// <param name="pe"><inheritdoc cref="Control.OnPaint" path="/param[@name='e']"/></param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            // Call the OnPaint method of the base class.
            base.OnPaint(pe);

            // Create a rectangle that represents the size of the control, minus 1 pixel.
            var area = new Rectangle(new Point(1, 1), new Size(_radius * 2 - 3, _radius * 2 - 3));

            // Fill an triangle in the rectangle represented by the control.
            pe.Graphics.FillEllipse(_fillBrush, area);

            // Draw an triangle in the rectangle represented by the control.
            pe.Graphics.DrawEllipse(_borderPenCurrent, area);
        }

        #endregion Methods
    }
}
