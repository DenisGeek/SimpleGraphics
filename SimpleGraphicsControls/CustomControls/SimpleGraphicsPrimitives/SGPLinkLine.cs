using SGTestingApp.CustomControls.SimpleGraphicsPrimitives;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGTestingApp.CustomControls.SimpleGraphicsPrimitives
{
    /// <summary>
    /// Link line <inheritdoc cref="SGPBase" path="/summary/inner"/>
    /// </summary>
    [ToolboxItem(false)]
    public partial class SGPLinkLine : Control
    {
        #region Fields and Properties

        /// <summary>
        /// First linked <inheritdoc cref="SGPBase" path="/summary/inner"/>
        /// </summary>
        public SGPBase? FirstSGP { get; set; }
        /// <summary>
        /// Second linked <inheritdoc cref="SGPBase" path="/summary/inner"/>
        /// </summary>
        public SGPBase? SecondSGP { get; set; }

        /// <summary>
        /// Link line pen
        /// </summary>
        protected Pen PenLinkLine { get; set; } = new(Color.OrangeRed);

        #endregion Fields and Properties

        /// <summary>
        /// Constructor, using <see cref="InitializeComponent"/> - <inheritdoc cref="InitializeComponent"/>
        /// </summary>
        public SGPLinkLine()
        {
            InitializeComponent();
            PenLinkLine.DashStyle = DashStyle.Dash;
            PenLinkLine.Width = 3;

            Location = new Point(0, 0);
            Size = new System.Drawing.Size(75, 75);
        }

        #region Methods

        /// <summary>
        /// <inheritdoc cref="SGPLinkLine"/> fill and draw, when <inheritdoc cref="Control.OnPaint" path="/summary"/>
        /// </summary>
        /// <param name="pe"><inheritdoc cref="Control.OnPaint" path="/param[@name='e']"/></param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);


            if (FirstSGP == null || SecondSGP == null)
            {
                return;
            }

            SetControlPosition();
            SetControlBounds();

            //BringToFront();

            // Create points that define line.
            Point firstSGPCenter = GetSGPCenter(FirstSGP);
            Point secondSGPCenter = GetSGPCenter(SecondSGP);

            // Draw an triangle in the rectangle represented by the control.
            Point bg = new Point(firstSGPCenter.X - Location.X, firstSGPCenter.Y - Location.Y);
            Point nd = new Point(secondSGPCenter.X - Location.X, secondSGPCenter.Y - Location.Y);            
            pe.Graphics.DrawLine(PenLinkLine, bg, nd);
        }

        /// <summary>
        /// Get center coordinates of <inheritdoc cref="SGPBase" path="/summary/inner"/>
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private Point GetSGPCenter(SGPBase item)
            => new Point(item.Location.X + item.Width / 2, item.Location.Y + item.Height / 2);

        /// <summary>
        /// Set control position bases on centres of <see cref="FirstSGP"/> and <see cref="SecondSGP"/>
        /// </summary>
        private void SetControlPosition()
        {
            if (FirstSGP == null || SecondSGP == null)
            {
                return;
            }

            Point firstSGPCenter = GetSGPCenter(FirstSGP);
            Point secondSGPCenter = GetSGPCenter(SecondSGP);

            Point newLocation = new(0, 0);
            newLocation.X = firstSGPCenter.X < secondSGPCenter.X ? firstSGPCenter.X : secondSGPCenter.X;
            newLocation.Y = firstSGPCenter.Y < secondSGPCenter.Y ? firstSGPCenter.Y : secondSGPCenter.Y;
            Location = newLocation;

            Width =  firstSGPCenter.X > secondSGPCenter.X ? firstSGPCenter.X : secondSGPCenter.X - newLocation.X;
            Height = firstSGPCenter.Y > secondSGPCenter.Y ? firstSGPCenter.Y : secondSGPCenter.Y - newLocation.Y;

            //g.DrawRectangle(PenLinkLine, new Rectangle(new Point(0, 0), new Size(this.Size.Width - 1, this.Size.Height - 1)));
        }

        /// <summary>
        /// Set control bouds based on control positions and centres of <see cref="FirstSGP"/> and <see cref="SecondSGP"/>
        /// </summary>
        private void SetControlBounds()
        {
            if (FirstSGP == null || SecondSGP == null)
            {
                return;
            }

            Point firstSGPCenter = GetSGPCenter(FirstSGP);
            Point secondSGPCenter = GetSGPCenter(SecondSGP);

            Point bg = new Point(firstSGPCenter.X - Location.X, firstSGPCenter.Y - Location.Y);
            Point nd = new Point(secondSGPCenter.X - Location.X, secondSGPCenter.Y - Location.Y);

            // Control edge
            var curvePath = new System.Drawing.Drawing2D.GraphicsPath();

            // Create points that define triangle edge polygon.
            Point point1 = new Point(bg.X - 2, bg.Y - 2);
            Point point2 = new Point(nd.X - 2, nd.Y - 2);
            Point point3 = new Point(nd.X + 2, nd.Y + 2);
            Point point4 = new Point(bg.X + 2, bg.Y + 2);
            Point[] curvePoints = { point1, point2, point3, point4 };

            // Define control edge
            curvePath.AddPolygon(curvePoints);

            // Set control region
            this.Region = new Region(curvePath);
        }

        #endregion Methods
    }
}
