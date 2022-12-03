namespace day2;

public class GameStrategy
{
    public static int Solve(IEnumerable<string> strategy)
        => strategy.Select(GameRound.Score).Sum();
}
