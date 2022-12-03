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
    [Theory]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", 16)]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 38)]
    [InlineData("PmmdzqPrVvPwwTWBwg", 42)]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", 22)]
    [InlineData("ttgJtRGJQctTZtZT", 20)]
    [InlineData("CrZsJsPPZsGzwwsLwLmpwMDw)]", 19)]
    
    public void GivenRucksackContents_WhenExampineAndFindPriority_ReturnsDuplicateItemPriority(string contents, int expectedPriority)
    {
        // Arrange
        // Act
        var result = ScoreRucksack.FindPriority(ScoreRucksack.Examine(contents));

        // Assert
        Assert.Equal(expectedPriority, result);
    }

    [Fact]
    public void GivenExampleData_WhenComputePart1_ReturnsEampleResult()
    {
        // Arrange
        var input = File.ReadAllLines("day3-example-input.txt");

        // Act
        var result = input.Select(line => ScoreRucksack.FindPriority(ScoreRucksack.Examine(line))).Sum();

        // Assert
        Assert.Equal(157, result);
    }
}