namespace AreaCalculation.Interfaces;

/// <summary>
/// Interface for all figures to calculate its area
/// </summary>
public interface IFigure
{
    /// <summary>
    /// Method to calculate area of the figure. Data for it is taken from inheritor's constructor
    /// </summary>
    /// <returns>Area of the figure</returns>
    public double CalculateArea();
}