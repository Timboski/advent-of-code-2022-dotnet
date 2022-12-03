namespace day2Test;

public class GameStrategyTest
{
    [Fact]
    public void GivenExampleInput_WhenRunStrategy_ReturnsCorrectResult()
    {
        // Arrange
        var exampleInput = File.ReadAllLines("day2-example-input.txt");

        // Act
        var result = GameStrategy.Solve(exampleInput);

        // Assert
        Assert.Equal(15, result);
    }
}