using System;
using GeometryCalculator.Interfaces;
using GeometryCalculator.Options.Interfaces;
using GeometryCalculator.Strategy.Interfaces;

namespace GeometryCalculator;

public abstract class ShapeBase<TOptions> : IShape
    where TOptions : IOptions
{
    protected readonly TOptions Options;
    private readonly ICalculationStrategy<TOptions> _calculationStrategy;
    private double? _cachedArea;

    protected ShapeBase(ICalculationStrategy<TOptions> calculationStrategy,
                        TOptions options)
    {
        _calculationStrategy = calculationStrategy ?? throw new ArgumentNullException(nameof(calculationStrategy));
        Options = options ?? throw new ArgumentNullException(nameof(options));
    }

    public double CalculateArea()
    {
        _cachedArea ??= _calculationStrategy.CalculateArea(Options);
        return _cachedArea.Value;
    }
}