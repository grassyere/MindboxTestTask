using System;
using GeometryCalculator.Options.Interfaces;
using GeometryCalculator.Strategy.Interfaces;

namespace GeometryCalculator.Strategy;

public class CircleCalculationStrategy : ICalculationStrategy<ICircleOptions>
{
    public double CalculateArea(IOptions options)
    {
        if (options is not ICircleOptions circleOptions)
        {
            throw new ArgumentException("Options must be of type ICircleOptions");
        }
        
        return Math.PI * Math.Pow(circleOptions.Radius, 2);
    }
}