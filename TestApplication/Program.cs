using System;
using GeometryCalculator;
using GeometryCalculator.Factory;
using GeometryCalculator.Factory.Interfaces;
using GeometryCalculator.Options;
using GeometryCalculator.Options.Interfaces;
using GeometryCalculator.Strategy;
using GeometryCalculator.Strategy.Interfaces;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddTransient<IShapeFactory, ShapeFactory>()
    .AddTransient<ICalculationStrategy<ICircleOptions>, CircleCalculationStrategy>()
    .AddTransient<ICalculationStrategy<ITriangleOptions>, TriangleCalculationStrategy>()
    .BuildServiceProvider();

var factory = serviceProvider.GetRequiredService<IShapeFactory>();

var circleOptions = new CircleOptions(5);
var circle = factory.CreateShape(circleOptions);
Console.WriteLine($"Circle area: {circle.CalculateArea()}");

var triangleOptions = new TriangleOptions(3, 4, 5);
var triangle = factory.CreateShape(triangleOptions);
Console.WriteLine($"Triangle area: {triangle.CalculateArea()}");

var isRightTriangle = (triangle as Triangle)?.IsRightTriangle();
Console.WriteLine($"Is right triangle: {isRightTriangle}");

