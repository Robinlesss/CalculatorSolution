using Calculator;
using Xunit;

// Här har vi testklass för Divider som testar division
public class DividerTests
{
	
	[Theory]
	[InlineData(10, 2, 5)]
	[InlineData(-10, 2, -5)]
    // Här kontrollerar vi att divisionen fungerar korrekt med olika värden dvs 10 / 2 = 5) 
    public void Divide_Returns(double a, double b, double expected)
	{
		var divider = new Divider();
		double result = divider.calulate(a, b);
		Assert.Equal(expected, result);
	}
    // Här testar vi att med division med 0 returnerar NaN och inte skickar felmeddelande
    [Fact]
	public void Divide_Zero_ReturnsNaN()
	{
		var divider = new Divider();
		double result = divider.calulate(10, 0);
		Assert.True(double.IsNaN(result));
	}
}