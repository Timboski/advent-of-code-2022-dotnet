namespace Day13Test;

public class ArrayElementTest
{
    [Theory]
    [InlineData("[1,1,3,1,1]", "[1,1,5,1,1]", Order.Correct)]
    [InlineData("[2,1,3,1,1]", "[1,1,5,1,1]", Order.Wrong)]
    [InlineData("[1,1,3,1,2]", "[1,1,5,1,1]", Order.Correct)]
    [InlineData("[1,2,3]", "[1,1,5,1,1]", Order.Wrong)]
    [InlineData("[1,1,3,4,5]", "[1,2,5]", Order.Correct)]
    [InlineData("[1,1,2,4]", "[1,1,2,4,5]", Order.Correct)]
    [InlineData("[1,1,2,4,5]", "[1,1,2,4]", Order.Wrong)]
    [InlineData("[[1],[0,1,2]", "[[2],[2,3,4]]", Order.Correct)]
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