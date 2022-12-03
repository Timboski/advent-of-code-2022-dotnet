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
}