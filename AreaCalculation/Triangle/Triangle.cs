using AreaCalculation.Interfaces;

namespace AreaCalculation.Triangle;

public class Triangle : IFigure<TriangleInfo>
{
    private readonly TriangleInfo _figureInfo;

    public Triangle(TriangleInfo figureInfo)
    {
        _figureInfo = figureInfo;
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
}