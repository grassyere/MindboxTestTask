using System;
using GeometryCalculator;
using GeometryCalculator.Options;
using GeometryCalculator.Strategy;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ShapeTests
    {
        [Test]
        public void Circle_Should_Calculate_Area_Correctly()
        {
            var options = new CircleOptions(5);
            var strategy = new CircleCalculationStrategy();
            var circle = new Circle(strategy, options);

            Assert.That(circle.CalculateArea(), Is.EqualTo(Math.PI * 25));
        }

        [Test]
        public void Triangle_Should_Calculate_Area_Correctly()
        {
            var options = new TriangleOptions(3, 4, 5);
            var strategy = new TriangleCalculationStrategy();
            var triangle = new Triangle(strategy, options);

            Assert.That(triangle.CalculateArea(), Is.EqualTo(6));
        }

        [Test]
        public void Triangle_Should_Detect_Right_Triangle()
        {
            var options = new TriangleOptions(3, 4, 5);
            var strategy = new TriangleCalculationStrategy();
            var triangle = new Triangle(strategy, options);

            Assert.That(triangle.IsRightTriangle(), Is.True);
        }

        [Test]
        public void Triangle_Should_Not_Detect_Right_Triangle()
        {
            var options = new TriangleOptions(5, 5, 5);
            var strategy = new TriangleCalculationStrategy();
            var triangle = new Triangle(strategy, options);

            Assert.That(triangle.IsRightTriangle(), Is.False);
        }
    }
}