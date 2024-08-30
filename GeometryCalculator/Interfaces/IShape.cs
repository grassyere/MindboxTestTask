using GeometryCalculator.Options.Interfaces;

namespace GeometryCalculator.Interfaces;

public interface IShape
{
    double CalculateArea();
}

public interface IShapeWithOptions<in TOptions> : IShape
    where TOptions : IOptions
{
    void SetOptions(TOptions options);
}
