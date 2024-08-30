using System;
using System.Collections.Generic;
using GeometryCalculator.Options.Interfaces;
using GeometryCalculator.Strategy.Interfaces;

namespace GeometryCalculator;

public class Triangle : ShapeBase<ITriangleOptions>
{
    public Triangle(ICalculationStrategy<ITriangleOptions> calculationStrategy,
                    ITriangleOptions options)
        : base(calculationStrategy, options)
    {
    }

    public bool IsRightTriangle()
    {
        var sides = new List<double> { Options.SideA, Options.SideB, Options.SideC };
        sides.Sort();

        var side1 = sides[0];
        var side2 = sides[1];
        var hypotenuse = sides[2];

        return Math.Abs(Math.Pow(hypotenuse, 2) - (Math.Pow(side1, 2) + Math.Pow(side2, 2))) < 1e-10;
    }

}