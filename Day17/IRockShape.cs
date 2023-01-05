namespace Day17
{
    public interface IRockShape
    {
        int Bottom { get; }
        int Height { get; }
        int Left { get; }
        int Top { get; }

        string GetLine(int pos, string background, char rockPixel = '@');
        bool IsCollision(int pos, IEnumerable<string> background);
        void MoveDown();
        void MoveLeft();
        void MoveRight();
    }
}