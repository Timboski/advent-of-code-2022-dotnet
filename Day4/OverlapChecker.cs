﻿namespace Day4;

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

    public static bool CheckPartial(string input)
    {        
        // Decode input
        var elves = input.Split(',');
        var elf1 = elves[0].Split('-');
        var elf2 = elves[1].Split('-');
        var start1 = int.Parse(elf1[0]);
        var end1 = int.Parse(elf1[1]);
        var start2 = int.Parse(elf2[0]);
        var end2 = int.Parse(elf2[1]);

        // Does Elf 1 range contain Elf 2 start?
        if (start2 >= start1 && start2 <= end1) return true;

        // Does Elf 1 range contain Elf 2 end?
        if (end2 >= start1 && end2 <= end1) return true;

        // Does Elf 2 range contain Elf 1 start?
        if (start1 >= start2 && start1 <= end2) return true;

        // Does Elf 2 range contain Elf 1 end?
        if (end1 >= start2 && end1 <= end2) return true;

        // Not a full overlap
        return false;
    }

    public static object Count(IEnumerable<string> input)
        => input.Where(Check).Count();

    public static object CountPartial(IEnumerable<string> input)
        => input.Where(CheckPartial).Count();
}
