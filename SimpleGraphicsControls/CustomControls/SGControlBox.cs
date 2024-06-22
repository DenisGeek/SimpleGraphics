using SGTestingApp.CustomControls.SimpleGraphicsPrimitives;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

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
        public bool IsModePrimitivesLinkSelection { get => _isModePrimitivesLinkSelection; }

        /// <summary>
        /// List of all <inheritdoc cref="SGPLinkLine"/>
        /// </summary>
        private List<SGPLinkLine> _LinkedLines = new List<SGPLinkLine>();

        #endregion Fields and Properties

        /// <summary>
        /// Constructor, using <see cref="InitializeComponent"/> - <inheritdoc cref="InitializeComponent"/>
        /// </summary>
        public SGControlBox()
        {
            InitializeComponent();
        }

        #region Methods

        #region Select Primitives

        /// <summary>
        /// If pressed Control key then activate selection mode
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

            // Link
            if (e.Control && e.KeyCode == Keys.L)
            {
                LinkedLinesAddAllSelectedSGP(_selectedPrimitives);
                _LinkedLines.ForEach(x => { x.BringToFront(); x.Invalidate(); });
                //Invalidate(true);
            }

            //Unlink
            if (e.Control && e.KeyCode == Keys.U)
            {
                LinkedLinesRemoveSelectedSGP(_selectedPrimitives);
                Invalidate(true);
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

        #endregion Select Primitives

        #region Manage Link Line

        /// <summary>
        /// Get all <see cref="SGPLinkLine"/> in <see cref="_LinkedLines"/>, which contains tis pair of <inheritdoc cref="SGPBase" path="/summary/inner"/>
        /// </summary>
        /// <returns>all <see cref="SGPLinkLine"/> with pair <inheritdoc cref="SGPBase" path="/summary/inner"/> </returns>
        private List<SGPLinkLine> LinkedLinesGetAllPairSGP(SGPBase first, SGPBase second)
            => _LinkedLines.Where(x => (x.FirstSGP == first || x.FirstSGP == second) && (x.SecondSGP == first || x.SecondSGP == second)).ToList();

        /// <summary>
        /// Do <see cref="_LinkedLines"/> contains tis pair of <inheritdoc cref="SGPBase" path="/summary/inner"/>
        /// </summary>
        /// <returns><typeparamref name="true"/> if contains</returns>
        private bool LinkedLinesContainsPairSGP(SGPBase first, SGPBase second)
            => LinkedLinesGetAllPairSGP(first, second).Count() > 0;

        /// <summary>
        /// Add into <see cref="_LinkedLines"/> new <see cref="SGPLinkLine"/> with pair <inheritdoc cref="SGPBase" path="/summary/inner"/>
        /// </summary>
        private void LinkedLinesAddPairSGP(SGPBase first, SGPBase second)
        {
            if (!LinkedLinesContainsPairSGP(first, second))
            {
                var newLinkLine = new SGPLinkLine() { FirstSGP = first, SecondSGP = second, Parent = this };
                _LinkedLines.Add(newLinkLine);

                Controls.Add(newLinkLine);
            }
        }

        /// <summary>
        /// Remove from <see cref="_LinkedLines"/> all <see cref="SGPLinkLine"/> with pair <inheritdoc cref="SGPBase" path="/summary/inner"/>
        /// </summary>
        private void LinkedLinesRemovePairSGP(SGPBase first, SGPBase second)
        {
            var allPairs = LinkedLinesGetAllPairSGP(first, second);
            if (allPairs.Count > 0)
            {
                var items4Remove = _LinkedLines.Where(x => allPairs.Contains(x)).ToList();

                _LinkedLines.RemoveAll(x => items4Remove.Contains(x));

                items4Remove.ForEach(x => { Controls.Remove(x); x.Dispose(); });
            }
        }

        /// <summary>
        /// Add all selected SGP in order selection to <see cref="_LinkedLines"/>
        /// </summary>
        /// <param name="selected"></param>
        private void LinkedLinesAddAllSelectedSGP(List<SGPBase> selected)
        {
            if (selected.Count <= 1)
            {
                return;
            }

            for (int i = 0; i < selected.Count - 1; i++)
            {
                LinkedLinesAddPairSGP(selected[i], selected[i + 1]);
            }
        }


        /// <summary>
        /// Remove all selected SGP in order selection from <see cref="_LinkedLines"/>
        /// </summary>
        /// <param name="selected"></param>
        private void LinkedLinesRemoveSelectedSGP(List<SGPBase> selected)
        {
            if (selected.Count <= 1)
            {
                return;
            }

            for (int i = 0; i < selected.Count - 1; i++)
            {
                LinkedLinesRemovePairSGP(selected[i], selected[i + 1]);
            }
        }

        /// <summary>
        /// Get all <see cref="SGPLinkLine"/> whrere contains this <inheritdoc cref="SGPBase" path="/summary/inner"/>
        /// </summary>
        /// <param name="item"></param>
        /// <returns>list of all <see cref="SGPLinkLine"/> whrere contains this <inheritdoc cref="SGPBase" path="/summary/inner"/> </returns>
        public List<SGPLinkLine> GetAllLineLimks3ThisSGP(SGPBase item)
            => _LinkedLines.Where(x => x.FirstSGP == item || x.SecondSGP == item).ToList();

        /// <summary>
        /// Recreate link lines
        /// </summary>
        /// <param name="linkLines">linkLines to recreate</param>
        public void RecreateLinkLines(List<SGPLinkLine> linkLines)
        {
            // Get pairs
            var pairs = linkLines.Select(x => new { x.FirstSGP, x.SecondSGP }).ToList();
            linkLines.Clear();

            // Remove link lines
            for (int i = 0; i < pairs.Count; i++)
            {
                LinkedLinesRemovePairSGP(pairs[i].FirstSGP!, pairs[i].SecondSGP!);
            }

            // Add link lines
            for (int i = 0; i < pairs.Count; i++)
            {
                LinkedLinesAddPairSGP(pairs[i].FirstSGP!, pairs[i].SecondSGP!);
            }

            _LinkedLines.ForEach(x => { x.BringToFront(); x.Invalidate(); });
        }

        #endregion Manage Link Line

        #endregion Methods
    }
}
