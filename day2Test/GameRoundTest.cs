namespace day2Test;

public class GameRoundTest
{
    [Theory]
    [InlineData("A Y", 8)]
    [InlineData("B X", 1)]
    [InlineData("C Z", 6)]
    public void GivenStrategyForRound_WhenScore_ReturnsCorrectResult(string strategy, int expectedScore)
    {
        // Arrange
        // Act
        var result = GameRound.Score(strategy);

        // Assert
        Assert.Equal(expectedScore, result);
    }
}