using FluentAssertions;
using Moq;
using SimpleGraphics.GraphicPrimitives;
using System.ComponentModel;


namespace TestSimpleGraphics
{
    public class GPBaseTest
    {
        [Trait("Category", "Unit tests for Graphic Primitives")]
        [Fact(DisplayName = "GPBase.IsPointInside Point inside Rectangle graphic primitive")]
        public void TestIsPointInsideRectangle()
        {
            // Arrange
            var someControl = new Control()
            {
                Width = 500,
                Height = 300,
                BackColor = Color.White,
            };

            var pRectangle = new GPRectangle(someControl, new(10, 10), new(200, 100));

            // Act 
            var locate = pRectangle.IsPointInside(new(100, 50));
            var notLocate = pRectangle.IsPointInside(new(5, 5));

            // Assert 
            locate.Should().BeTrue();
            notLocate.Should().BeFalse();
        }

        [Trait("Category", "Unit tests for Graphic Primitives")]
        [Fact(DisplayName = "GPBase.IsPointInside Point inside TriangleEquilateral graphic primitive")]
        public void TestIsPointInsideTriangleEquilateral()
        {
            // Arrange
            var someControl = new Control()
            {
                Width = 500,
                Height = 300,
                BackColor = Color.White,
            };

            var pRectangle = new GPTriangleEquilateral(someControl, new(10, 10), new(200, 100));

            // Act 
            var locate = pRectangle.IsPointInside(new(55, 55));
            var notLocate = pRectangle.IsPointInside(new(5, 5));

            // Assert 
            locate.Should().BeTrue();
            notLocate.Should().BeFalse();
        }
    }
}