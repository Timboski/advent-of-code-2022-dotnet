using System.Drawing;
using System.Text;

namespace Day14;

public class Cave
{
    private readonly BoundingBox _box;
    private readonly Dictionary<(int, int), char> _grid = new();
    private readonly Point _sandEntry;

    public Cave(BoundingBox box, Point sandEntry)
    {
        _box = box;
        _grid[(sandEntry.X, sandEntry.Y)] = '+';
        _sandEntry = sandEntry;
    }

    public void AddPath(IEnumerable<Point> points)
    {
        var current = points.First();
        foreach (var point in points.Skip(1))
        {
            AddLine(current, point);
            current = point;
        }
    }

    private void AddLine(Point first, Point second)
    {
        var startX = Math.Min(first.X, second.X);
        var endX = Math.Max(first.X, second.X);
        var startY = Math.Min(first.Y, second.Y);
        var endY = Math.Max(first.Y, second.Y);

        for (int x = startX; x <= endX; x++)
            for (int y = startY; y <= endY; y++)
                _grid[(x, y)] = '#';
    }

    public override string ToString()
    {
        var lineSize = _box.MaxX - _box.MinX;
        var lines = new List<string>(_box.MaxY - _box.MinY);

        for (int y = _box.MinY; y < _box.MaxY; y++)
        {
            var sb = new StringBuilder(lineSize);
            for (int x = _box.MinX; x < _box.MaxX; x++)
                if (_grid.ContainsKey((x, y))) sb.Append(_grid[(x, y)]);
                else sb.Append('.');

            lines.Add(sb.ToString());
        }

        return string.Join(Environment.NewLine, lines);
    }

    public void AddPaths(IEnumerable<IEnumerable<Point>> paths)
    {
        foreach (var path in paths) AddPath(path);
    }

    public Point FallFrom(Point point)
    {
        // Try straight down, then left, then right.
        var y = point.Y + 1;
        foreach (var x in new[] { point.X, point.X - 1, point.X + 1 })
            if (CheckAndCreatePoint(x, y, out Point newPoint)) return newPoint;
        
        // Move not possible
        return point;
    }

    private bool CheckAndCreatePoint(int x, int y, out Point point)
    {
        if (!_grid.ContainsKey((x, y)))
        {
            point = new Point(x, y);
            return true;
        }

        point = Point.Empty;
        return false;
    }

    public bool AddSand()
    {
        var current = _sandEntry;
        while (true)
        {
            var newPos = FallFrom(current);
            if (newPos == current)
            {
                // Sand stopped - add to the grad.
                _grid[(current.X, current.Y)] = 'o';
                return true;
            }

            if (!_box.ContainsPoint(newPos)) return false;

            current = newPos;
        }
    }

    public int AddSandUntilStable()
    {
        var iterations = 0;
        while (AddSand()) iterations++;
        return iterations;
    }
}
