using AreaCalculation.Interfaces;

namespace AreaCalculation.Circle;

/// <summary>
/// Interface to store information, required to calculate area of a circle (radius)
/// </summary>
public class CircleInfo: IFigureInfo
{
    public double Radius { get; set; }
}