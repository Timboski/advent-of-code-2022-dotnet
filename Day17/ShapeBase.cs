namespace Day17;

public abstract class ShapeBase : IRockShape
{
    protected int _bottomPos;
    protected int _left = 3;

    protected ShapeBase(int bottomPos) 
        => _bottomPos = bottomPos;

    public int Bottom => _bottomPos;

    public int Left => _left;

    public int Top => _bottomPos + Height;

    public abstract int Height { get; }

    public abstract string GetLine(int pos, string background, char rockPixel = '@');

    public abstract bool IsCollision(int pos, IEnumerable<string> background);

    public void MoveDown() => _bottomPos--;

    public void MoveLeft() => _left--;

    public void MoveRight() => _left++;

    protected static string SetPixels(string background, int start, int count, char rockPixel) 
        => background[0..start] +
            new string(rockPixel, count) +
            background[(start + count)..^0];

    protected static bool CheckCollisionOnLine(string background, int pos, int count)
        => background
            .Skip(pos)
            .Take(count)
            .Any(a => a != '.');
}