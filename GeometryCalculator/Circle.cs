using GeometryCalculator.Options.Interfaces;
using GeometryCalculator.Strategy.Interfaces;

namespace GeometryCalculator;

public class Circle(
    ICalculationStrategy<ICircleOptions> calculationStrategy,
    ICircleOptions options)
    : ShapeBase<ICircleOptions>(calculationStrategy, options);