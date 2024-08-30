namespace GeometryCalculator.Options.Interfaces;

public interface ITriangleOptions : IOptions
{ 
    double SideA { get; }
    
    double SideB { get; }
    
    double SideC { get; }
}