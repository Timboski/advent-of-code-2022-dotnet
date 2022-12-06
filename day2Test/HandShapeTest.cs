namespace Day2Test;

public class HandShapeTest
{
    [Theory]
    [InlineData(HandShape.Shape.Rock, HandShape.Shape.Rock, 4)]
    [InlineData(HandShape.Shape.Rock, HandShape.Shape.Paper, 1)]
    [InlineData(HandShape.Shape.Rock, HandShape.Shape.Scissors, 7)]
    [InlineData(HandShape.Shape.Paper, HandShape.Shape.Rock, 8)]
    [InlineData(HandShape.Shape.Paper, HandShape.Shape.Paper, 5)]
    [InlineData(HandShape.Shape.Paper, HandShape.Shape.Scissors, 2)]
    [InlineData(HandShape.Shape.Scissors, HandShape.Shape.Rock, 3)]
    [InlineData(HandShape.Shape.Scissors, HandShape.Shape.Paper, 9)]
    [InlineData(HandShape.Shape.Scissors, HandShape.Shape.Scissors, 6)]
    public void GivenHand_WhenScoreAgainstOpponent_ReturnsCorrectResult(HandShape.Shape hand, HandShape.Shape opponent, int expectedScore)
    {
        // Arrange
        var sut = HandShapeFactory.Create(hand);
        var opp = HandShapeFactory.Create(opponent);

        // Act
        var result = sut.Score(opp);

        // Assert
        Assert.Equal(expectedScore, result);
    }
}