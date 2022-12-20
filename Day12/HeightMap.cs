using System.Drawing;
using System.Text;

namespace Day12;

public class HeightMap
{
    private readonly char _startHeight;
    private readonly char[,] _mapData;

    public HeightMap(string map, char startHeight = 'a')
        : this(map.Split(Environment.NewLine).ToArray(), startHeight)
    {
    }

    public HeightMap(string[] map, char startHeight = 'a')
        : this(ParseMap(map), startHeight)
    {
    }

    public HeightMap(char[,] map, char startHeight)
    {
        _startHeight = startHeight;
        _mapData = map;
        XSize = _mapData.GetLength(0);
        YSize = _mapData.GetLength(1);
        for (int x = 0; x < XSize; ++x)
        {
            for (int y = 0; y < YSize; ++y)
            {
                var glyph = _mapData[x, y];

                if (glyph == 'S') Start = new(x, y);
            }
        }

        IsComplete = startHeight == 'E';
        if (Start.X < 0) throw new NoStartException();
    }

    public override string ToString()
    {
        var mapData = new List<string>(YSize);

        for (int y = 0; y < YSize; ++y)
        {
            var sb = new StringBuilder(XSize);
            for (int x = 0; x < XSize; ++x)
            {
                sb.Append(_mapData[x, y]);
            }

            mapData.Add(sb.ToString());
        }

        return string.Join(Environment.NewLine, mapData);
    }

    public string GetVisitedMap(HashSet<Point> visited)
    {
        var mapData = new List<string>(YSize);

        for (int y = 0; y < YSize; ++y)
        {
            var sb = new StringBuilder(XSize);
            for (int x = 0; x < XSize; ++x)
            {
                if (visited.Contains(new Point(x, y)))
                    //sb.Append('.');
                    sb.Append(char.ToUpper(_mapData[x, y]));
                else
                    sb.Append(_mapData[x, y]);
            }

            mapData.Add(sb.ToString());
        }

        return string.Join(Environment.NewLine, mapData);
    }

    public Point Start { get; } = new(-1, -1);

    public bool IsComplete { get; }

    public int XSize { get; }

    public int YSize { get; }

    public int PathLength => CountVisitedElements();

    public List<HeightMap> FindSteps() 
        => new[] {
                new Point(Start.X, Start.Y - 1),
                new Point(Start.X, Start.Y + 1),
                new Point(Start.X - 1, Start.Y),
                new Point(Start.X + 1, Start.Y)
            }
            .SelectMany(CheckLocation)
            .ToList();

    public HeightMap Invert()
    {
        var invertedMap = (char[,])_mapData.Clone();

        for (int x = 0; x < XSize; ++x)
        {
            for (int y = 0; y < YSize; ++y)
            {
                invertedMap[x, y] = invertedMap[x, y] switch
                {
                    'S' => 'E',
                    'E' => 'S',
                    'a' => 'E',
                    char c => (char)('z' - (c - 'a'))
                };
            }
        }

        return new HeightMap(invertedMap, 'a');
    }

    private IEnumerable<HeightMap> CheckLocation(Point pos)
    {
        if (pos.X < 0) yield break;
        if (pos.X >= XSize) yield break;
        if (pos.Y < 0) yield break;
        if (pos.Y >= YSize) yield break;

        var level = _mapData[pos.X, pos.Y];
        if (level == '#') yield break;
        var testLevel = level == 'E' ? 'z' : level;
        if (testLevel > _startHeight + 1) yield break;

        var newMap = (char[,])_mapData.Clone();
        newMap[Start.X, Start.Y] = '#';
        newMap[pos.X, pos.Y] = 'S';
        yield return new HeightMap(newMap, level);
    }

    private static char[,] ParseMap(string[] map)
    {
        var mapData = new char[map[0].Length, map.Length];
        foreach (var (line, y) in map.Select((line, rowIndex) => (line, rowIndex)))
        {
            foreach (var (glyph, x) in line.Select((glyph, columnIndex) => (glyph, columnIndex)))
            {
                mapData[x, y] = glyph;
            }
        }

        return mapData;
    }

    private int CountVisitedElements()
    {
        var count = 0;
        for (int x = 0; x < XSize; ++x)
        {
            for (int y = 0; y < YSize; ++y)
            {
                if (_mapData[x, y] == '#') ++count;
            }
        }
        return count;
    }
}
