using AreaCalculation.Interfaces;

namespace AreaCalculation.Triangle;

public class Triangle : IFigure
{
    /// <summary>
    /// Information, required for calculating triangle's area 
    /// </summary>
    private readonly TriangleInfo _figureInfo;

    public Triangle(TriangleInfo figureInfo)
    {
        if (IsTrianglePossible(figureInfo))
        {
            _figureInfo = figureInfo;
        }
        else
        {
            throw new ArgumentException("Triangle with this sides is impossible");
        }
    }

    /// <inheritdoc/>
    public double CalculateArea()
    {
        if (IsRightTriangle())
        {
            var cathets = new List<double> { _figureInfo.SideA, _figureInfo.SideB, _figureInfo.SideC }
                .OrderBy(s => s).Take(2).ToList();

            return (cathets[0] * cathets[1]) / 2;
        }

        var perimeter = _figureInfo.SideA + _figureInfo.SideB + _figureInfo.SideC;
        var halfMeter = perimeter / 2;

        return Math.Sqrt(halfMeter * (halfMeter - _figureInfo.SideA) * (halfMeter - _figureInfo.SideB) *
                         (halfMeter - _figureInfo.SideC));
    }

    /// <summary>
    /// Checks if the triangle is right (has a 90 degrees angle)
    /// </summary>
    /// <returns>
    /// Flag, which shows a "rightness" of the triangle
    /// </returns>
    private bool IsRightTriangle()
    {
        return (
            (_figureInfo.SideA * _figureInfo.SideA + _figureInfo.SideB * _figureInfo.SideB ==
             _figureInfo.SideC * _figureInfo.SideC) ||
            (_figureInfo.SideA * _figureInfo.SideA + _figureInfo.SideC * _figureInfo.SideC ==
             _figureInfo.SideB * _figureInfo.SideB) ||
            (_figureInfo.SideC * _figureInfo.SideC + _figureInfo.SideB * _figureInfo.SideB ==
             _figureInfo.SideA * _figureInfo.SideA)
        );
    }

    /// <summary>
    /// Checks if the triangle with passed sides is possible
    /// </summary>
    /// <param name="figureInfo">Information about sides of the triangle</param>
    /// <returns>Flag, which shows possibilty of existence of the triangle</returns>
    public static bool IsTrianglePossible(TriangleInfo figureInfo)
    {
        return (figureInfo.SideA + figureInfo.SideB >= figureInfo.SideC) &&
               (figureInfo.SideA + figureInfo.SideC >= figureInfo.SideB) &&
               (figureInfo.SideB + figureInfo.SideC >= figureInfo.SideA);
    }
}