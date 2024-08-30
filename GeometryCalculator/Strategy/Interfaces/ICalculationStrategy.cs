using GeometryCalculator.Options.Interfaces;

namespace GeometryCalculator.Strategy.Interfaces;

public interface ICalculationStrategy<TOptions> 
    where TOptions : IOptions
{
    double CalculateArea(IOptions options);
}