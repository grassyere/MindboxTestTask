using System;
using GeometryCalculator;
using GeometryCalculator.Factory;
using GeometryCalculator.Options;
using GeometryCalculator.Options.Interfaces;
using GeometryCalculator.Strategy.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ShapeFactoryTests
    {
        private ServiceProvider _serviceProvider;
        private Mock<ICalculationStrategy<ICircleOptions>> _circleStrategyMock;
        private Mock<ICalculationStrategy<ITriangleOptions>> _triangleStrategyMock;
        private ShapeFactory _shapeFactory;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();

            _circleStrategyMock = new Mock<ICalculationStrategy<ICircleOptions>>();
            _triangleStrategyMock = new Mock<ICalculationStrategy<ITriangleOptions>>();

            services.AddSingleton(_circleStrategyMock.Object);
            services.AddSingleton(_triangleStrategyMock.Object);

            _serviceProvider = services.BuildServiceProvider();
            _shapeFactory = new ShapeFactory(_serviceProvider);
        }

        [TearDown]
        public void TearDown()
        {
            if (_serviceProvider is IDisposable disposableProvider)
            {
                disposableProvider.Dispose();
            }
        }

        [Test]
        public void CreateShape_Should_Create_Circle()
        {
            var options = new CircleOptions(5);
            _circleStrategyMock.Setup(s => s.CalculateArea(It.IsAny<ICircleOptions>())).Returns(Math.PI * 25);

            var shape = _shapeFactory.CreateShape(options) as Circle;

            Assert.That(shape, Is.Not.Null);
            Assert.That(shape.CalculateArea(), Is.EqualTo(Math.PI * 25));
        }

        [Test]
        public void CreateShape_Should_Create_Triangle()
        {
            var options = new TriangleOptions(3, 4, 5);
            _triangleStrategyMock.Setup(s => s.CalculateArea(It.IsAny<ITriangleOptions>())).Returns(6);

            var shape = _shapeFactory.CreateShape(options) as Triangle;

            Assert.That(shape, Is.Not.Null);
            Assert.That(shape.CalculateArea(), Is.EqualTo(6));
        }

        [Test]
        public void CreateShape_Should_Throw_NotSupportedException_For_Unknown_Options()
        {
            var options = new Mock<IOptions>().Object;

            Assert.Throws<NotSupportedException>(() => _shapeFactory.CreateShape(options));
        }
    }
}
