namespace Day4;

public static class OverlapChecker
{
    public static bool Check(string input)
    {
        // Decode input
        var elves = input.Split(',');
        var elf1 = elves[0].Split('-');
        var elf2 = elves[1].Split('-');
        var start1 = int.Parse(elf1[0]);
        var end1 = int.Parse(elf1[1]);
        var start2 = int.Parse(elf2[0]);
        var end2 = int.Parse(elf2[1]);

        // Does Elf 1 do all of Elf 2 work?
        if (start1 <= start2 && end1 >= end2) return true;

        // Does Elf 2 do all of Elf 1 work?
        if (start2 <= start1 && end2 >= end1) return true;

        // Not a full overlap
        return false;
    }
}
