using System;
using GeometryCalculator.Factory.Interfaces;
using GeometryCalculator.Interfaces;
using GeometryCalculator.Options.Interfaces;
using GeometryCalculator.Strategy.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GeometryCalculator.Factory;

public class ShapeFactory : IShapeFactory
{
    private readonly IServiceProvider _serviceProvider;

    public ShapeFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IShape CreateShape<TOptions>(TOptions options)
        where TOptions : IOptions
    {
        return options switch
        {
            ICircleOptions circleOptions => new Circle(_serviceProvider.GetRequiredService<ICalculationStrategy<ICircleOptions>>(), circleOptions),
            ITriangleOptions triangleOptions => new Triangle(_serviceProvider.GetRequiredService<ICalculationStrategy<ITriangleOptions>>(), triangleOptions),
            _ => throw new NotSupportedException($"Shape for options type {typeof(TOptions).Name} is not supported.")
        };
    }
}
