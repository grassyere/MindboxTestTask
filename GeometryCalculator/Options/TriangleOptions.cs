using System;
using GeometryCalculator.Options.Interfaces;

namespace GeometryCalculator.Options;

public class TriangleOptions : ITriangleOptions
{
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }

    public TriangleOptions(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            throw new ArgumentException("All sides must be positive");

        if (sideA + sideB <= sideC 
            || sideA + sideC <= sideB 
            || sideB + sideC <= sideA)
            throw new ArgumentException("The sides do not form a valid triangle");

        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }
}
