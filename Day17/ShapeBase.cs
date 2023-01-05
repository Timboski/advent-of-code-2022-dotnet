namespace Day17;

public abstract class ShapeBase : IRockShape
{
    protected long _bottomPos;
    protected int _left = 3;

    protected ShapeBase(long bottomPos) 
        => _bottomPos = bottomPos;

    public long Bottom => _bottomPos;

    public int Left => _left;

    public long Top => _bottomPos + Height;

    public abstract int Height { get; }

    public abstract string GetLine(long vPos, string background, char rockPixel = '@');

    public abstract bool IsCollision(int hPos, IEnumerable<string> background);

    public void MoveDown() => _bottomPos--;

    public void MoveLeft() => _left--;

    public void MoveRight() => _left++;

    protected static string SetPixels(string background, int start, int count, char rockPixel) 
        => background[0..start] +
            new string(rockPixel, count) +
            background[(start + count)..^0];

    protected static bool CheckCollisionOnLine(string background, int hPos, int count)
        => background
            .Skip(hPos)
            .Take(count)
            .Any(a => a != '.');
}