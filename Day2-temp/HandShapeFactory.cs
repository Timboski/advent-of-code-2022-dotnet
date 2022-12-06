namespace Day2;

public static class HandShapeFactory
{
    public static HandShape Create(HandShape.Shape shape)
        => shape switch
        {
            HandShape.Shape.Rock => new Rock(),
            HandShape.Shape.Paper => new Paper(),
            HandShape.Shape.Scissors => new Scissors(),
            _ => throw new ArgumentOutOfRangeException(nameof(shape)),
        };

    internal static HandShape Create(string shape)
        => shape switch
        {
            "A" or "X" => new Rock(),
            "B" or "Y" => new Paper(),
            "C" or "Z" => new Scissors(),
            _ => throw new ArgumentOutOfRangeException(nameof(shape)),
        };

    internal static HandShape Create(string desiredResult, HandShape opponent) 
        => desiredResult switch
        {
            "X" => opponent.CreateLosingOpponent(),
            "Y" => opponent.CreateDrawingOpponent(),
            "Z" => opponent.CreateWinningOpponent(),
            _ => throw new ArgumentOutOfRangeException(nameof(desiredResult)),
        };
}
