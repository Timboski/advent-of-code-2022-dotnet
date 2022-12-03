namespace Day3Test;

public class ScoreRucksackTest
{
    [Theory]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp",'p')]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 'L')]
    [InlineData("PmmdzqPrVvPwwTWBwg", 'P')]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", 'v')]
    [InlineData("ttgJtRGJQctTZtZT", 't')]
    [InlineData("CrZsJsPPZsGzwwsLwLmpwMDw)]", 's')]
    public void GivenRucksackContents_WhenExamine_ReturnsDuplicateItem(string contents, char duplicateItem)
    {
        // Arrange
        // Act
        var result = ScoreRucksack.Examine(contents);

        // Assert
        Assert.Equal(duplicateItem, result);
    }

    [Theory]
    [InlineData('a', 1)]
    [InlineData('z', 26)]
    [InlineData('A', 27)]
    [InlineData('Z', 52)]
    public void GivenItemCode_WhenFindPriority_ReturnsExpectedPriority(char itemCode, int expectedPriority) 
    {
        // Arrange
        // Act
        var result = ScoreRucksack.FindPriority(itemCode);

        // Assert
        Assert.Equal(expectedPriority, result);
    }
}