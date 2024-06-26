﻿using System.ComponentModel;

namespace SGTestingApp.CustomControls.SimpleGraphicsPrimitives
{
    /// <summary>
    /// Rectangle <inheritdoc cref="SGPBase" path="/summary/inner"/>
    /// </summary>
    [ToolboxItem(true)]
    public partial class SGPRectangle : SGPBase
    {
        #region Fields and Properties

        /// <summary>
        /// Public readonly <inheritdoc cref="Control.Height" path="/returns"/>
        /// </summary>
        public int ThisHeight { get => Height; }
        /// <summary>
        /// Public readonly <inheritdoc cref="Control.Width" path="/returns"/>
        /// </summary>
        public int ThisWidth { get => Width; }

        #endregion Fields and Properties

        /// <summary>
        /// Constructor, using <see cref="InitializeComponent"/> - <inheritdoc cref="InitializeComponent"/>
        /// </summary>
        public SGPRectangle()
        {
            InitializeComponent();
        }

        #region Methods

        /// <summary>
        /// <inheritdoc cref="SGPRectangle"/> fill and draw, when <inheritdoc cref="Control.OnPaint" path="/summary"/>
        /// </summary>
        /// <param name="pe"><inheritdoc cref="Control.OnPaint" path="/param[@name='e']"/></param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            // Call the OnPaint method of the base class.
            base.OnPaint(pe);

            // Create a rectangle that represents the size of the control, minus 1 pixel.
            var area = new Rectangle(new Point(0, 0), new Size(this.Size.Width - 1, this.Size.Height - 1));

            // Draw an rectangle in the rectangle represented by the control.
            pe.Graphics.FillRectangle(_fillBrush, area);

            // Draw an rectangle in the rectangle represented by the control.
            pe.Graphics.DrawRectangle(_borderPenCurrent, area);
        }

        #endregion Methods
    }
}
