﻿using AreaCalculation.Interfaces;

namespace AreaCalculation.Circle;

public class Circle : IFigure<CircleInfo>
{
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

    public double CalculateArea()
    {
        return Math.PI * _figureInfo.Radius;
    }
}