namespace Day2;

public class Rock : HandShape
{
	public Rock() : base(Shape.Rock)
	{
	}

	protected override bool IsWin(HandShape opponent)
		=> opponent.ShapeType == Shape.Scissors;

    internal override HandShape CreateDrawingOpponent()
        => new Rock();

    internal override HandShape CreateLosingOpponent()
        => new Scissors();

    internal override HandShape CreateWinningOpponent()
        => new Paper();
}
