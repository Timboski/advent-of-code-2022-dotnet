namespace day2;

public class Paper : HandShape
{
	public Paper() : base(Shape.Paper)
	{
	}

	protected override bool IsWin(HandShape opponent)
		=> opponent.ShapeType == Shape.Rock;
}
