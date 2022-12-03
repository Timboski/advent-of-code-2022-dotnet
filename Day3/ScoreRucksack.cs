namespace Day3;

public static class ScoreRucksack
{
    public static char Examine(string contents)
    {
        var len = contents.Length;
        var half = len / 2;
        var start = contents[0..half];
        var end = contents[half..^0];
        var duplicates = start.Intersect(end);
        return duplicates.First();
    }
}
