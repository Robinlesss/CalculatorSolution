using Moq;
using Xunit;
using Calculator;

public class SaveToFileTests
{
    // Mock-test av ISaveToFile med Moq och xUnit
    [Fact]
    public void AddCalculation()
    {
        var mock = new Mock<ISaveToFile>();
        mock.Object.AddCalculation("test");
        mock.Verify(x => x.AddCalculation("test"), Times.Once);
    }
}
