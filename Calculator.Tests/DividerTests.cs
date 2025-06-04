using Calculator;
using Xunit;

// H�r har vi testklass f�r Divider som testar division
public class DividerTests
{
	
	[Theory]
	[InlineData(10, 2, 5)]
	[InlineData(-10, 2, -5)]
    // H�r kontrollerar vi att divisionen fungerar korrekt med olika v�rden dvs 10 / 2 = 5) 
    public void Divide_Returns(double a, double b, double expected)
	{
		var divider = new Divider();
		double result = divider.calulate(a, b);
		Assert.Equal(expected, result);
	}
    // H�r testar vi att med division med 0 returnerar NaN och inte skickar felmeddelande
    [Fact]
	public void Divide_Zero_ReturnsNaN()
	{
		var divider = new Divider();
		double result = divider.calulate(10, 0);
		Assert.True(double.IsNaN(result));
	}
}