namespace day2;

public class Rock : HandShape
{
	public Rock() : base(Shape.Rock)
	{
	}

	protected override bool IsWin(HandShape opponent)
		=> opponent.ShapeType == Shape.Scissors;
}
