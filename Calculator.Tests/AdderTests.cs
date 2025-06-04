using Xunit;
using Calculator;

// Testklass för Adder
public class AdderTests
{
    [Fact]
    public void Calculate_Adds()
    {
        var adder = new Adder();
        double result = adder.calulate(3, 5);
        Assert.Equal(8, result);
    }
}
