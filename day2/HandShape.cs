namespace day2;

public abstract class HandShape
{
    public enum Shape { Rock = 1, Paper = 2, Scissors = 3 };

    protected HandShape(Shape shape) 
        => ShapeType = shape;

    internal Shape ShapeType { get; }

    public int Score(HandShape opponent)
    {
        var handValue = (int)ShapeType;
        if (IsDraw(opponent)) return handValue + 3;
        if (IsWin(opponent)) return handValue + 6;
        return handValue;
    }

    protected abstract bool IsWin(HandShape opponent);

    private bool IsDraw(HandShape opponent) 
        => ShapeType == opponent.ShapeType;

    internal abstract HandShape CreateLosingOpponent();

    internal abstract HandShape CreateDrawingOpponent();

    internal abstract HandShape CreateWinningOpponent();
}
