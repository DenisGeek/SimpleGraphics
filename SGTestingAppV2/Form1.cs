using SimpleGraphics.CustomControls;
using SimpleGraphics.GraphicPrimitives;

namespace SGTestingAppV2
{
    public partial class Form1 : Form
    {
        #region Fields and Properties

        private GPRectangle? pRectangle;
        private GPCircle? pCircle;
        private GPTriangleEquilateral? pTriangleEquilateral;
        private GPTriangleIsosceles? pTriangleIsosceles;

        #endregion Fields and Properties

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //pRectangle = new(this, new(10, 10), new(200, 100));
            //pCircle = new(this, new(210, 10), new(200, 100));
            //pTriangleEquilateral = new(this, new(210, 10), new(200, 100));
            //pTriangleIsosceles = new(this, new(210, 10), new(200, 100));

            gpLayout1.Primitives.Add(new GPRectangle(gpLayout1, new(10, 50), new(200, 100)));
            gpLayout1.Primitives.Add(new GPCircle(gpLayout1, new(10, 10), new(100, 100)));
            gpLayout1.Primitives.Add(new GPTriangleEquilateral(gpLayout1, new(10, 10), new(200, 100)));
            gpLayout1.Primitives.Add(new GPTriangleIsosceles(gpLayout1, new(210, 100), new(200, 100)));
        }
    }
}