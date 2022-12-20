namespace Day13Test;

public class IntegerElementTest
{
    [Fact]
    public void GivenIntegerElements_WhenCheckIsBeforeHigherIntegerElement_ReturnsTrue()
    {
        // Arrange
        var sut = new IntegerElement(4);
        var higher = new IntegerElement(8);

        // Act
        var correctOrder = sut.IsBefore(higher);

        // Assert
        Assert.True(correctOrder);
    }
}