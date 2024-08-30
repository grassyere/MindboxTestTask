using System;
using GeometryCalculator.Options.Interfaces;

namespace GeometryCalculator.Options;

public class CircleOptions : ICircleOptions
{
    public double Radius { get; set; }

    public CircleOptions(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Radius must be positive", nameof(radius));

        Radius = radius;
    }
}
