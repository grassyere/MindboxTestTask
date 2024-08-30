using System;
using GeometryCalculator.Options.Interfaces;
using GeometryCalculator.Strategy.Interfaces;

namespace GeometryCalculator.Strategy;

public class TriangleCalculationStrategy : ICalculationStrategy<ITriangleOptions>
{
    public double CalculateArea(IOptions options)
    {
        if (options is not ITriangleOptions triangleOptions)
        {
            throw new ArgumentException("Options must be of type ITriangleOptions");
        }
        
        var semiPerimeter = (triangleOptions.SideA + triangleOptions.SideB + triangleOptions.SideC) / 2;
        
        return Math.Sqrt(semiPerimeter 
                         * (semiPerimeter - triangleOptions.SideA) 
                         * (semiPerimeter - triangleOptions.SideB) 
                         * (semiPerimeter - triangleOptions.SideC));
    }
}