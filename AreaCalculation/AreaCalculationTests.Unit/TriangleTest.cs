using AreaCalculation.Triangle;
using FluentAssertions;

namespace AreaCalculationTests.Unit;

public class TriangleTest
{
    [Theory(DisplayName = "Tries to create triangle with wrong sides must throw an error")]
    [InlineData(10, 3, 5)]
    [InlineData(12, 6, 5)]
    [InlineData(7, 15, 5)]
    [InlineData(7, 2, 20)]
    public void ImpossibleTriangleCreation__RaiseError(double sideA, double sideB, double sideC)
    {
        // Prepare
        var action = () => new Triangle(new TriangleInfo { SideA = sideA, SideB = sideB, SideC = sideC});
        
        // Act & check
        action.Should().Throw<ArgumentException>().WithMessage("Triangle with this sides is impossible");
    }

    [Theory(DisplayName = "Should correctly calculate area of the right triangle")]
    [InlineData(3, 3, 6, 0)]
    [InlineData(3, 4, 5, 6)]
    [InlineData(2, 3, 4, 2.9047375096556)]
    [InlineData(5, 7, 3, 6.4951905283833)]
    public void RightTriangle__CalculateArea(double sideA, double sideB, double sideC, double result)
    {
        // Prepare
        var triangle = new Triangle(new TriangleInfo { SideA = sideA, SideB = sideB, SideC = sideC});
        
        // Act
        var area = triangle.CalculateArea();
        var difference = Math.Abs(area - result);
        
        // Check
        difference.Should().BeLessOrEqualTo(0.00001);
    }

    [Theory(DisplayName = "Should correctly check possibility of triangle's existence")]
    [InlineData(3, 4, 5)]
    [InlineData(2, 3, 4)]
    [InlineData(3, 3, 6)]
    [InlineData(5, 7, 3)]
    public void TriangleSides__CheckPossibilityOfExistence(double sideA, double sideB, double sideC)
    {
        // Prepare & Act
        var result = Triangle.IsTrianglePossible(new TriangleInfo { SideA = sideA, SideB = sideB, SideC = sideC });

        // Check
        result.Should().BeTrue();
    }
}