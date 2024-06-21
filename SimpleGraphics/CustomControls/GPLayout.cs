using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SimpleGraphics.GraphicPrimitives;

namespace SimpleGraphics.CustomControls
{
    /// <summary>
    /// Layout of <inheritdoc cref="GPBase" path="/summary/name"/>
    /// </summary>
    public partial class GPLayout : Control
    {
        #region Fields and Properties

        /// <summary>
        /// <inheritdoc cref="GPBase" path="/summary/name"/>s at this layout
        /// </summary>
        public List<GPBase> Primitives { get; set; } = new List<GPBase>();

        /// <summary>
        /// initial mouse position when <inheritdoc cref="_mouseButton"/>
        /// </summary>
        private Point _mousePosition = new(0, 0);

        /// <summary>
        /// Mouse over the primitive
        /// </summary>
        private GPBase? _activePrimitive;

        /// <summary>
        /// Selected <inheritdoc cref="SGPBase" path="/summary/inner"/>s
        /// </summary>
        private List<GPBase> _selectedPrimitives = new List<GPBase>();
        /// <summary>
        /// Selction mode active or not
        /// </summary>
        private bool _isModePrimitivesLinkSelection = false;
        /// <summary>
        /// <inheritdoc cref="_isModePrimitivesLinkSelection"/>
        /// </summary>
        public bool IsModePrimitivesLinkSelection { get => _isModePrimitivesLinkSelection; }

        #endregion Fields and Properties

        /// <summary>
        /// Constructor, using <see cref="InitializeComponent"/> - <inheritdoc cref="InitializeComponent"/>
        /// </summary>
        public GPLayout()
        {
            InitializeComponent();
        }

        #region Methods

        #region Select Primitives

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            WriteText($"{PointToClient(MousePosition)}", 5);
            WriteText($"{MousePosition}", 4);
            WriteText($"{PointToClient(_mousePosition)}", 3);
            WriteText($"{PointToScreen(_mousePosition)}", 2);
            WriteText($"{_mousePosition}", 1);

            void WriteText(string text, int shiftFromButtom)
            {
                var font = new Font("Arial", 16);
                SizeF textLen = pe.Graphics.MeasureString(text, font);
                Point textPlace = Point.Add(Location, new(Width / 2 - (int)textLen.Width / 2, Height - (int)textLen.Height * shiftFromButtom - 3));
                pe.Graphics.DrawString(text, font, Brushes.Blue, textPlace);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            Point mousePositionNew = new(e.X, e.Y);
            //Point mousePositionNew = new(20, 20);

            var newActivePrimitive = GetFirsPrimitiveAtPoint(mousePositionNew);
            if (newActivePrimitive != _activePrimitive)
            {
                _activePrimitive?.SetMode(GPBase.ModeType.None);
                _activePrimitive = newActivePrimitive;
                _activePrimitive?.SetMode(GPBase.ModeType.Active);
            }

            _mousePosition = mousePositionNew;
            Invalidate();
        }

        private GPBase? GetFirsPrimitiveAtPoint(Point point)
        {
            GPBase? res = null;

            for (int i = Primitives.Count - 1; i >= 0; i--)
            {
                var primitive = Primitives[i];
                if (primitive.IsPointInside(point))
                {
                    res = primitive;
                    break;
                }
            }

            return res;
        }

        /// <summary>
        /// If handle pressed keys
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            // Select
            if (e.Control)
            {
                _isModePrimitivesLinkSelection = true;
            }
        }

        /// <summary>
        /// if released Control key then deactivate selection mode
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            var k = e.KeyCode;
            //if (e.Control)
            {
                _isModePrimitivesLinkSelection = false;
                _selectedPrimitives.Clear();
            }

            Invalidate(true);
        }

        #endregion Select Primitives

        #endregion Methods
    }
}
