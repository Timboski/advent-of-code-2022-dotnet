namespace Day2;

public class GameStrategy
{
    public static int Solve(IEnumerable<string> strategy)
        => strategy.Select(GameRound.Score).Sum();

    public static int SolveFixed(IEnumerable<string> strategy)
        => strategy.Select(GameRound.ScoreFixed).Sum();
}
