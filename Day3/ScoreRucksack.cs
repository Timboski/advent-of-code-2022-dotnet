namespace Day3;

public static class ScoreRucksack
{
    public static char Examine(string contents)
    {
        var half = contents.Length / 2;
        return contents[0..half].Intersect(contents[half..^0]).First();
    }

    public static int FindPriority(char itemCode)
        => char.IsLower(itemCode) ?
            itemCode - 'a' + 1 :
            itemCode - 'A' + 27;
}
