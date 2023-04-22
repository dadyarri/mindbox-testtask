using AreaCalculation.Interfaces;

namespace AreaCalculation.Triangle;

public class Triangle : IFigure<TriangleInfo>
{
    private readonly TriangleInfo _figureInfo;

    public Triangle(TriangleInfo figureInfo)
    {
        if (IsTrianglePossible(figureInfo))
        {
            _figureInfo = figureInfo;
        }

        throw new ArgumentException("Triangle with this sides is impossible");
    }

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

    private bool IsTrianglePossible(TriangleInfo figureInfo)
    {
        return (figureInfo.SideA + figureInfo.SideB > figureInfo.SideC) &&
               (figureInfo.SideA + figureInfo.SideC > figureInfo.SideB) &&
               (figureInfo.SideB + figureInfo.SideC > figureInfo.SideA);
    }
}