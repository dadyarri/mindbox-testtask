using AreaCalculation.Circle;
using FluentAssertions;

namespace AreaCalculationTests.Unit;

public class CircleTest
{
    [Theory(DisplayName = "Could calculate area of circle with positive (greater than zero) radius correctly")]
    [InlineData(2, 12.566370614)]
    [InlineData(3, 28.2743338815)]
    [InlineData(4, 50.265482456)]
    public void CircleWithPositiveRadius__ValidArea(double radius, double result)
    {
        // Prepare
        var circle = new Circle(new CircleInfo {Radius = radius});
        
        // Act
        var area = circle.CalculateArea();
        var difference = area - result;
        
        // Check
        difference.Should().BeLessOrEqualTo(0.00001);
    }

    [Theory(DisplayName = "Tries to create circle with non-positive (less or equal than zero) radius must raise")]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-2)]
    [InlineData(-3)]
    public void CircleWithNonPositiveRadius__ShouldRaiseException(double radius)
    {
        // Prepare
        var action = () => new Circle(new CircleInfo { Radius = radius });
        
        // Act & check
        action.Should().Throw<ArgumentException>().WithMessage("Circle can't exist");
    }
}