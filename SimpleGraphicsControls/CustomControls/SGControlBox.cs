using SGTestingApp.CustomControls.SimpleGraphicsPrimitives;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGTestingApp.CustomControls
{
    public partial class SGControlBox : Control
    {
        #region Fields and Properties

        /// <summary>
        /// Selected <inheritdoc cref="SGPBase" path="/summary/inner"/>s
        /// </summary>
        private List<SGPBase> _selectedPrimitives = new List<SGPBase>();
        /// <summary>
        /// Selction mode active or not
        /// </summary>
        private bool _isModePrimitivesLinkSelection = false;
        /// <summary>
        /// <inheritdoc cref="_isModePrimitivesLinkSelection"/>
        /// </summary>
        public bool IsModePrimitivesLinkSelection { get => _isModePrimitivesLinkSelection;}

        #endregion Fields and Properties

        /// <summary>
        /// Constructor, using <see cref="InitializeComponent"/> - <inheritdoc cref="InitializeComponent"/>
        /// </summary>
        public SGControlBox()
        {
            InitializeComponent();
        }
        
        #region Methods

        /// <summary>
        /// If pressed Control key then activate selection mode
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Control)
            {
                _isModePrimitivesLinkSelection = true;
                //_selectedPrimitives.Clear();
            }
        }

        /// <summary>
        /// if released Control key then deactivate selection mode
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            //if (e.Control)
            {
                _isModePrimitivesLinkSelection = false;
                // DO STUFF
                _selectedPrimitives.Clear();
            }

            Invalidate(true);
        }

        /// <summary>
        /// add to <inheritdoc cref="_selectedPrimitives"/>
        /// </summary>
        /// <param name="item"></param>
        public void SelectedPrimitivesAdd(SGPBase item)
            => _selectedPrimitives.Add(item);
        /// <summary>
        /// Remove from <inheritdoc cref="_selectedPrimitives"/>
        /// </summary>
        /// <param name="item"></param>
        public void SelectedPrimitivesRemove(SGPBase item)
            => _selectedPrimitives.Remove(item);
        /// <summary>
        /// Check <inheritdoc cref="_selectedPrimitives"/> contains the control
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool SelectedPrimitivesCheck(SGPBase item)
            => _selectedPrimitives.Contains(item);

        #endregion Methods
    }
}
