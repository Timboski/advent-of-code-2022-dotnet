namespace day2;

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

    public static HandShape Create(string shape)
        => shape switch
        {
            "A" or "X" => new Rock(),
            "B" or "Y" => new Paper(),
            "C" or "Z" => new Scissors(),
            _ => throw new ArgumentOutOfRangeException(nameof(shape)),
        };
}
