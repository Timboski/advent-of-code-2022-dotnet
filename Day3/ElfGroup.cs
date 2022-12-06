namespace Day3;

public class ElfGroup
{
    public static char Examine(string elf1, string elf2, string elf3) 
        => elf1.Intersect(elf2).Intersect(elf3).First();

    public static int BadgePriority(IEnumerable<string> elves)
        => elves.Chunk(3).Select(group => ScoreRucksack.FindPriority(Examine(group[0], group[1], group[2]))).Sum();
}
