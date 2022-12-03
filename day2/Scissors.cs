namespace day2;

public class Scissors : HandShape
{
	public Scissors() : base(Shape.Scissors)
	{
	}

	protected override bool IsWin(HandShape opponent)
		=> opponent.ShapeType == Shape.Paper;
}
