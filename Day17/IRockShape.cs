namespace Day17
{
    public interface IRockShape
    {
        long Bottom { get; }
        int Height { get; }
        int Left { get; }
        long Top { get; }

        string GetLine(long vPos, string background, char rockPixel = '@');
        bool IsCollision(int hPos, IEnumerable<string> background);
        void MoveDown();
        void MoveLeft();
        void MoveRight();
    }
}