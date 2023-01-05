namespace Day17;

public class NullRock : IRockShape
{
    public long Bottom => 0;

    public int Height => 0;

    public int Left => 0;

    public long Top => 0;

    public string GetLine(long vPos, string background, char rockPixel = '@') 
        => background;

    public bool IsCollision(int hPos, IEnumerable<string> background) 
        => throw new NotImplementedException();

    public void MoveDown() => throw new NotImplementedException();

    public void MoveLeft() => throw new NotImplementedException();

    public void MoveRight() => throw new NotImplementedException();
}
