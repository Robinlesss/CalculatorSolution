using Calculator;
using Xunit;

// Testklass f�r Multiplier som testar multiplikation
public class MultiplierTests
{
    [Theory]
    [InlineData(2, 3, 6)]
    [InlineData(-2, 3, -6)]
    [InlineData(0, 5, 0)]
    // Vi testar positiva, negativa och noll-v�rden.
    public void Multiply_Returns(double a, double b, double expected)
    {
        var multiplier = new Multiplier();
        double result = multiplier.calulate(a, b);
        Assert.Equal(expected, result);
    }
}