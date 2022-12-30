using System.Drawing;

namespace Day14;

public class BoundingBox
{
    public BoundingBox(Point initialPoint)
    {
        MinX = initialPoint.X;
        MinY = initialPoint.Y;
        MaxX = initialPoint.X + 1;
        MaxY = initialPoint.Y + 1;
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

    public int MinX { get; private set; }
    public int MaxX { get; private set; }
    public int MinY { get; private set; }
    public int MaxY { get; private set; }
}
