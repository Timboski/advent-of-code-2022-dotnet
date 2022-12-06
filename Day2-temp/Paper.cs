namespace Day2;

public class Paper : HandShape
{
	public Paper() : base(Shape.Paper)
	{
	}

	protected override bool IsWin(HandShape opponent)
		=> opponent.ShapeType == Shape.Rock;

    internal override HandShape CreateDrawingOpponent()
        => new Paper();

    internal override HandShape CreateLosingOpponent()
        => new Rock();

    internal override HandShape CreateWinningOpponent()
        => new Scissors();
}
