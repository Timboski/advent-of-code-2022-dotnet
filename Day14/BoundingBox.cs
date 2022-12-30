using System.Drawing;

namespace Day14;

public class BoundingBox
{
    public BoundingBox(Point initialPoint) 
        : this(initialPoint.X, 
              initialPoint.Y, 
              initialPoint.X + 1,
              initialPoint.Y + 1)
    {
    }

    public BoundingBox(int minX, int minY, int maxX, int maxY)
    {
        MinX = minX;
        MinY = minY;
        MaxX = maxX;
        MaxY = maxY;
    }

    public void EnclosePoints(IEnumerable<Point> points)
    {
        foreach (Point point in points) EnclosePoint(point);
    }

    private void EnclosePoint(Point point)
    {
        MinX = Math.Min(MinX, point.X);
        MinY = Math.Min(MinY, point.Y);
        MaxX = Math.Max(MaxX, point.X + 1);
        MaxY = Math.Max(MaxY, point.Y + 1);
    }

    public bool ContainsPoint(Point point)
    {
        if (point.X < MinX) return false;
        if (point.X >= MaxX) return false;
        if (point.Y < MinY) return false;
        if (point.Y >= MaxY) return false;
        return true;
    }

    public int MinX { get; private set; }
    public int MaxX { get; private set; }
    public int MinY { get; private set; }
    public int MaxY { get; private set; }
}
