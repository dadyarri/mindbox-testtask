using AreaCalculation.Interfaces;

namespace AreaCalculation.Circle;

public class Circle: IFigure<CircleInfo>
{
    
    private readonly CircleInfo _figureInfo;
    
    public Circle(CircleInfo figureInfo)
    {
        _figureInfo = figureInfo;
    }
    
    public double CalculateArea()
    {
        return Math.PI * _figureInfo.Radius;
    }
}