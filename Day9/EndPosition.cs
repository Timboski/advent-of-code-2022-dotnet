namespace Day9;

public record EndPosition
{
    public EndPosition(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }

    public int Y { get; }

    public EndPosition North => new EndPosition(X, Y + 1);
    public EndPosition South => new EndPosition(X, Y - 1);
}
