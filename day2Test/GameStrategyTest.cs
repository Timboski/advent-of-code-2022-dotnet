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

    [Fact]
    public void GivenProblemInput_WhenRunStrategy_ReturnsCorrectResult()
    {
        // Arrange
        var input = File.ReadAllLines("day2-input.txt");

        // Act
        var result = GameStrategy.Solve(input);

        // Assert
        Assert.Equal(11449, result);
    }

    [Fact]
    public void GivenExampleInput_WhenRunStrategyFixed_ReturnsCorrectResult()
    {
        // Arrange
        var exampleInput = File.ReadAllLines("day2-example-input.txt");

        // Act
        var result = GameStrategy.SolveFixed(exampleInput);

        // Assert
        Assert.Equal(12, result);
    }
}