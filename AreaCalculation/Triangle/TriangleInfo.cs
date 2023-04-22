using AreaCalculation.Interfaces;

namespace AreaCalculation.Triangle;

/// <summary>
/// Interface to store information, required to calculate area of a triangle (length of sides)
/// </summary>
public class TriangleInfo: IFigureInfo
{
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }
}