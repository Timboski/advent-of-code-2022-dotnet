namespace Day17;

public class NullRock : IRockShape
{
    public int Bottom => 0;

    public int Height => 0;

    public int Left => 0;

    public int Top => 0;

    public string GetLine(int pos, string background, char rockPixel = '@') 
        => background;

    public bool IsCollision(int pos, IEnumerable<string> background) 
        => throw new NotImplementedException();

    public void MoveDown() => throw new NotImplementedException();

    public void MoveLeft() => throw new NotImplementedException();

    public void MoveRight() => throw new NotImplementedException();
}
