namespace day2;

public class GameStrategy
{
    public static int Solve(IEnumerable<string> strategy)
        => strategy.Select(ComputeScore).Sum();

    private static int ComputeScore(string strategyEntry)
        => GameRound.Score(strategyEntry);
}
