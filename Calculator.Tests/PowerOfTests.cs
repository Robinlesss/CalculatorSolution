using Calculator;
using Xunit;

// Testklass för PowerOf som testar exponentiering
public class PowerOfTests
{
    [Theory]
    [InlineData(2, 3, 8)]
    [InlineData(4, 0.5, 2)]
    public void PowerOf_Returns(double a, double b, double expected)
    {
        var power = new PowerOf();
        double result = power.calulate(a, b);
        Assert.Equal(expected, result, 5); 
    }
}
