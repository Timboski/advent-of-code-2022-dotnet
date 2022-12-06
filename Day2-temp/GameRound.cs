namespace Day2;

public static class GameRound
{
    public static int Score(string strategyEntry)
    {
        var hands = strategyEntry.Split(' ');
        var opponent = HandShapeFactory.Create(hands[0]);
        var player = HandShapeFactory.Create(hands[1]);
        return player.Score(opponent);
    }

    public static int ScoreFixed(string strategyEntry)
    {
        var hands = strategyEntry.Split(' ');
        var opponent = HandShapeFactory.Create(hands[0]);
        var player = HandShapeFactory.Create(hands[1], opponent);
        return player.Score(opponent);
    }
}