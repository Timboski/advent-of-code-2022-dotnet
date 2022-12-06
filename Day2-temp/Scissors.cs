namespace Day2;

public class Scissors : HandShape
{
	public Scissors() : base(Shape.Scissors)
	{
	}

	protected override bool IsWin(HandShape opponent)
		=> opponent.ShapeType == Shape.Paper;

    internal override HandShape CreateDrawingOpponent()
        => new Scissors();

    internal override HandShape CreateLosingOpponent()
        => new Paper();

    internal override HandShape CreateWinningOpponent()
        => new Rock();
}
