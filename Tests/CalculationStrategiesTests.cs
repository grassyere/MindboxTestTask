using System;
using GeometryCalculator.Options;
using GeometryCalculator.Strategy;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class CalculationStrategiesTests
    {
        private CircleCalculationStrategy _circleStrategy;
        private TriangleCalculationStrategy _triangleStrategy;

        [SetUp]
        public void Setup()
        {
            _circleStrategy = new CircleCalculationStrategy();
            _triangleStrategy = new TriangleCalculationStrategy();
        }

        [Test]
        public void CircleCalculationStrategy_Should_Calculate_Area_Correctly()
        {
            var options = new CircleOptions(5);
            var area = _circleStrategy.CalculateArea(options);
            Assert.That(area, Is.EqualTo(Math.PI * 25));
        }

        [Test]
        public void TriangleCalculationStrategy_Should_Calculate_Area_Correctly()
        {
            var options = new TriangleOptions(3, 4, 5);
            var area = _triangleStrategy.CalculateArea(options);
            Assert.That(area, Is.EqualTo(6));
        }

        [Test]
        public void TriangleCalculationStrategy_Should_Throw_Exception_For_Invalid_Options()
        {
            var invalidOptions = new CircleOptions(5);
            Assert.Throws<ArgumentException>(() => _triangleStrategy.CalculateArea(invalidOptions));
        }
    }
}