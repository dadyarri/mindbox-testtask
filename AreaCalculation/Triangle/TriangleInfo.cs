using AreaCalculation.Interfaces;

namespace AreaCalculation.Triangle;

public class TriangleInfo: IFigureInfo
{
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }
}