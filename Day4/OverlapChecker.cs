namespace Day4;

public static class OverlapChecker
{
    public static bool Check(string input)
    {
        var (elf1, elf2) = DecodeInput(input);
        if (elf1.FullyContains(elf2)) return true;
        if (elf2.FullyContains(elf1)) return true;
        return false;
    }

    public static bool CheckPartial(string input)
    {
        var (elf1, elf2) = DecodeInput(input);
        if (elf1.ContainsPoint(elf2.start)) return true;
        if (elf1.ContainsPoint(elf2.end)) return true;
        if (elf2.ContainsPoint(elf1.start)) return true;
        if (elf2.ContainsPoint(elf1.end)) return true;
        return false;
    }

    public static object Count(IEnumerable<string> input)
        => input.Where(Check).Count();

    public static object CountPartial(IEnumerable<string> input)
        => input.Where(CheckPartial).Count();

    private static bool FullyContains(this (int start, int end) elf1, (int start, int end) elf2) 
        => elf1.start <= elf2.start && elf1.end >= elf2.end;

    private static bool ContainsPoint(this (int start, int end) elf, int point) 
        => point >= elf.start && point <= elf.end;

    private static ((int start, int end) elf1, (int start, int end) elf2) DecodeInput(string input)
    {
        var elves = input.Split(',');
        var elf1 = elves[0].Split('-');
        var elf2 = elves[1].Split('-');
        var start1 = int.Parse(elf1[0]);
        var end1 = int.Parse(elf1[1]);
        var start2 = int.Parse(elf2[0]);
        var end2 = int.Parse(elf2[1]);
        return ((start1, end1), (start2, end2));
    }
}
