using Xunit;
using Moq;
using Calculator;

// Testklass för CalculatorEngine som mockar IOperation för att testa vår CalculatorEngine
public class CalculatorEngineTests
{
    [Fact]
    public void ExecuteCallsOperation()
    {
        var mock = new Mock<IOperation>(); // Mockar IOperation
        mock.Setup(x => x.calulate(2, 3)).Returns(5); //Definierar förväntat beteende

        var engine = new CalculatorEngine(mock.Object); // Injektar mocken i CalculatorEngine
        double result = engine.Calculate(0, 2, 3);

        Assert.Equal(5, result);
        mock.Verify(x => x.calulate(2, 3), Moq.Times.Once);
    }
}
