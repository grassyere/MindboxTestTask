using System;
using GeometryCalculator.Options;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class OptionsTests
    {
        [Test]
        public void CircleOptions_Should_Throw_Exception_For_NonPositive_Radius()
        {
            Assert.Throws<ArgumentException>(() => new CircleOptions(0));
            Assert.Throws<ArgumentException>(() => new CircleOptions(-1));
        }

        [Test]
        public void TriangleOptions_Should_Throw_Exception_For_Invalid_Sides()
        {
            Assert.Throws<ArgumentException>(() => new TriangleOptions(1, 2, 3));
            Assert.Throws<ArgumentException>(() => new TriangleOptions(0, 4, 5));
            Assert.Throws<ArgumentException>(() => new TriangleOptions(3, 4, -1));
        }
    }
}
