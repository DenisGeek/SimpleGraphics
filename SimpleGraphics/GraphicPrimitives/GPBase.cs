using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace SimpleGraphics.GraphicPrimitives
{
    /// <summary>
    /// Base <name>graphic primitive</name>
    /// <list type="bullet">
    ///     <item>
    ///         <list type="bullet">
    ///             <listheader><see cref="_graphicContainer"/> - Continer for this <inheritdoc cref="GPBase" path="/summary/name"/> </listheader>
    ///         </list>
    ///     </item>
    ///     <item>Size of <see cref="_graphicContainer"/> same like <see cref="Parent"/> size</item>
    ///     <item>For paint on <see cref="_graphicContainer"/> used <see cref="Location"/> and <see cref="Size"/> </item>
    ///     <item>Paint performs in <see cref="ContainerPaintGraphic"/></item>
    ///     <item>When parent size change recreates <see cref="_graphicContainer"/> in <see cref="OnParentResize"/></item>
    ///     <item>Graphic from <see cref="_graphicContainer"/> transfers to <see cref="Parent"/> in <see cref="OnParentPaint"/></item>
    /// </list>
    /// </summary>
    public abstract class GPBase : IDisposable
    {
        #region Fields and Properties

        /// <summary>
        /// Continer for this <inheritdoc cref="GPBase" path="/summary/name"/> drawing
        /// </summary>
        protected Bitmap _graphicContainer;

        /// <summary>
        /// Suspend paint this <inheritdoc cref="GPBase" path="/summary/name"/>
        /// </summary>
        public bool SuspendPaint { get; set; } = false;

        private Control _parent;
        /// <summary>
        ///  <inheritdoc cref="Control.Parent"/>
        /// </summary>
        public Control Parent { get => _parent; set { LeaveParent(_parent); _parent = value; AddToParent(_parent); } }

        #region Position

        /// <summary>
        /// <inheritdoc cref="Location"/>
        /// </summary>
        private Point _location;
        /// <summary>
        /// The location at <see cref="Parent"/> of this <inheritdoc cref="GPBase" path="/summary/name"/>
        /// </summary>
        public Point Location { get => _location; set { _location = value; Parent?.Invalidate(); } }

        /// <summary>
        /// <inheritdoc cref="Size"/>
        /// </summary>
        private Size _size;
        /// <summary>
        /// The size of this <inheritdoc cref="GPBase" path="/summary/name"/>.
        /// </summary>
        public Size Size { get => _size; set { _size = value; OnSizeChanged(); Parent?.Invalidate(); } }

        #endregion Position

        #region Colors

        /// <summary>
        /// <inheritdoc cref="_fillColor"/>
        /// </summary>
        public Color FillColor { get => _fillColor; set { _fillColor = value; _fillBrush = new SolidBrush(value); Parent?.Invalidate(); } }
        /// <summary>
        /// Fill color for <inheritdoc cref="SGPBase" path="/summary/inner"/>, needs for demonstrte color in editor
        /// </summary>
        private Color _fillColor = Color.Green;
        /// <summary>
        /// Colored brush for <inheritdoc cref="SGPBase" path="/summary/inner"/>, using in OnPaint
        /// </summary>
        protected Brush _fillBrush = Brushes.Green;

        /// <summary>
        /// border pen, depends on mouse hover
        /// </summary>
        protected Pen _borderPenCurrent = Pens.Blue;

        /// <summary>
        /// <inheritdoc cref="_borderColor"/>
        /// </summary>
        public Color BorderColor { get => _borderColor; set { _borderColor = value; _borderPen = new(value); Parent?.Invalidate(); } }
        /// <summary>
        /// Border color for <inheritdoc cref="SGPBase" path="/summary/inner"/>, needs for demonstrte color in editor
        /// </summary>
        private Color _borderColor = Color.Blue;
        /// <summary>
        /// Colored pen for <inheritdoc cref="SGPBase" path="/summary/inner"/>, using in OnPaint
        /// </summary>
        protected Pen _borderPen = Pens.Blue;

        #endregion Colors

        /// <summary>
        /// Flag the class already disposed
        /// </summary>
        private bool disposedValue;

        #endregion Fields and Properties

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent">Parent <see cref="Control"/></param>
        /// <param name="location">Location at hfrent control</param>
        /// <param name="size">Size of <inheritdoc cref="GPBase" path="/summary/name"/></param>
        public GPBase(Control parent, Point location, Size size)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            SuspendPaint = true;
            
            Parent = parent;
            Location = location;
            Size = size;

            FillColor = Color.Green;
            BorderColor = Color.Blue;
            _borderPenCurrent = _borderPen;

            OnSizeChanged();
            ContainerPaintGraphic();

            SuspendPaint = false;

            Parent.Invalidate();
        }


        #region Methods

        /// <summary>
        /// Repaint the graphic primitive
        /// </summary>
        public abstract void ContainerPaintGraphic();

        /// <summary>
        /// Event nandler for <see cref="Parent"/>, when parent <inheritdoc cref="Control.OnPaint" path="/summary"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnParentPaint(object? sender, PaintEventArgs e)
            => e.Graphics.DrawImage(_graphicContainer, new Point(0, 0));

        #region Methods parent changing

        /// <summary>
        /// Create container <see cref="_graphicContainer"/> for this <inheritdoc cref="GPBase" path="/summary/name"/>
        /// </summary>
        /// <param name="parent"></param>
        private void ReCreateGraphicContainer(Control parent)
        {
            if (parent == null) return;
            _graphicContainer?.Dispose();
            _graphicContainer = new Bitmap(parent.Width, parent.Height, PixelFormat.Format32bppPArgb);
            //_graphicContainer = new Bitmap(parent.Width, parent.Height, PixelFormat.Format32bppArgb);
        }

        /// <summary>
        /// Event nandler for <see cref="Parent"/>, when parent <inheritdoc cref="Control.OnResize" path="/summary"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnParentResize(object? sender, EventArgs e)
        {
            ReCreateGraphicContainer(Parent);
            ContainerPaintGraphic();
            Parent.Invalidate();
        }

        /// <summary>
        /// Add this <inheritdoc cref="GPBase" path="/summary/name"/> to control <see cref="Parent"/> 
        /// </summary>
        /// <param name="parent"></param>
        private void AddToParent(Control parent)
        {
            ReCreateGraphicContainer(parent);

            parent.Paint += OnParentPaint;
            Parent.Resize += OnParentResize;
            parent.Invalidate();
        }

        /// <summary>
        /// Leave current control <see cref="Parent"/> 
        /// </summary>
        /// <param name="parent"></param>
        private void LeaveParent(Control parent)
        {
            if (parent == null) return;

            parent.Paint -= OnParentPaint;
            parent.Resize -= OnParentResize;
        }

        #endregion Methods parent changing

        /// <summary>
        /// Raises when <see cref="Size"/> change
        /// </summary>
        protected virtual void OnSizeChanged() { }


        /// <summary>
        /// Are point inside primitive
        /// </summary>
        /// <param name="point">testing point</param>
        /// <returns><typeparamref name="true"/> if inside of this <inheritdoc cref="GPBase" path="/summary/name"/></returns>
        public bool IsPointInside(Point point)
        {
            if (point.X<0|| point.X>Size.Width|| point.Y< 0 || point.Y > Size.Height)
            {
                return false;
            }
            
            bool res = _graphicContainer.GetPixel(point.X, point.Y).ToArgb() != Parent.BackColor.ToArgb();
            return res;
        }

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _graphicContainer.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~GPBase()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable

        #endregion Methods
    }
}
