using Calculator;
using Xunit;

// Testklass för Subtractor som testar subtraktion
public class SubtractorTests
{
    [Theory]
    [InlineData(10, 5, 5)]
    [InlineData(-3, -3, 0)]
    [InlineData(0, 5, -5)]
    public void Subtract_ReturnsCorrectResult(double a, double b, double expected)
    {
        var subtractor = new Subtractor();
        double result = subtractor.calulate(a, b);
        Assert.Equal(expected, result);
    }
}