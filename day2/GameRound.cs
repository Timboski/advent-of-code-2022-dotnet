namespace day2;

public static class GameRound
{
    public static int Score(string strategyEntry)
    {
        var hands = strategyEntry.Split(' ');
        var opponent = hands[0].Create();
        var player = hands[1].Create();
        return player.Score(opponent);
    }
}