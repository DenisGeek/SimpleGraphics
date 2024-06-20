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
        public GPLayout()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
