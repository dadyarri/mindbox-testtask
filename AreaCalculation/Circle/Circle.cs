using AreaCalculation.Interfaces;

namespace AreaCalculation.Circle;

public class Circle : IFigure
{
    /// <summary>
    /// Information, required for calculating circle's area 
    /// </summary>
    private readonly CircleInfo _figureInfo;

    public Circle(CircleInfo figureInfo)
    {
        if (figureInfo.Radius > 0)
        {
            _figureInfo = figureInfo;
        }
        else
        {
            throw new ArgumentException("Circle can't exist");
        }
    }

    /// <inheritdoc/>
    public double CalculateArea()
    {
        return Math.PI * _figureInfo.Radius;
    }
}