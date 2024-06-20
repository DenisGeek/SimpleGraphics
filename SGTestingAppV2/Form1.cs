using SimpleGraphics.GraphicPrimitives;

namespace SGTestingAppV2
{
    public partial class Form1 : Form
    {
        #region Fields and Properties

        private GPRectangle pRectangle;

        #endregion Fields and Properties

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pRectangle = new(this, new(10, 10), new(200, 100));
            var locate = pRectangle.IsPointInside(new(100, 50));
            var notLocate = pRectangle.IsPointInside(new(5, 5));
        }
    }
}