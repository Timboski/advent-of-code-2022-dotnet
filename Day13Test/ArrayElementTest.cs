namespace Day13Test;

public class ArrayElementTest
{
    [Theory]
    [InlineData("[1,1,3,1,1]", "[1,1,5,1,1]", Order.Correct)]
    public void GivenTwoArrayStrings_WhenParseAndCompare_ReturnsExpectedOrder(string leftArray, string rightArray, Order expectedOrder)
    {
        // Arrange
        var left = new ArrayElement(leftArray);
        var right = new ArrayElement(rightArray);

        // Act
        var order = left.CheckOrder(right);

        // Assert
        Assert.Equal(expectedOrder, order);
    }
}