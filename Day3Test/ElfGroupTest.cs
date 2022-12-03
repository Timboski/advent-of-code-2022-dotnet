namespace Day3Test;

public class ElfGroupTest
{
    [Theory]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "PmmdzqPrVvPwwTWBwg", 'r')]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", "ttgJtRGJQctTZtZT", "CrZsJsPPZsGzwwsLwLmpwMDw)]", 'Z')]
    public void GivenRucksackContentsFromThreeElves_WhenExamine_ReturnsDuplicateItem(string elf1, string elf2, string elf3, char duplicateItem)
    {
        // Arrange
        // Act
        var result = ElfGroup.Examine(elf1, elf2, elf3);

        // Assert
        Assert.Equal(duplicateItem, result);
    }
}