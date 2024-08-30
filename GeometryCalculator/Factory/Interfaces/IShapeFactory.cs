using GeometryCalculator.Interfaces;
using GeometryCalculator.Options.Interfaces;

namespace GeometryCalculator.Factory.Interfaces;

public interface IShapeFactory
{
    IShape CreateShape<TOptions>(TOptions options)
        where TOptions : IOptions;
}