namespace Day17;

public class HorizontalShape
{
	private int _left = 3;
	private int _bottomPos;

    public HorizontalShape(int bottomPosition) 
		=> _bottomPos = bottomPosition;

    public int Bottom => _bottomPos;
    public int Top => _bottomPos + 1;

	public string GetLine(int pos, string background, char rockPixel='@')
	{
		if (pos != Bottom) return background;

		return background[0.._left] +
			new string(rockPixel, 4) +
			background[(_left + 4)..^0];
	}

    public void MoveRight() => _left++;
}
