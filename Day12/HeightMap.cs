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

                if (glyph == 'E') IsComplete = false;
            }
        }

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

    public Point Start { get; } = new(-1, -1);

    public bool IsComplete { get; } = true;

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
            .SelectMany(pos => CheckLocation(pos))
            .ToList();

    private IEnumerable<HeightMap> CheckLocation(Point pos)
    {
        if (pos.X < 0) yield break;
        if (pos.X >= XSize) yield break;
        if (pos.Y < 0) yield break;
        if (pos.Y >= YSize) yield break;

        var accessableHeights = new List<char>() 
            { (char)(_startHeight - 1), _startHeight, (char)(_startHeight + 1) };
        if (_startHeight >= 'y') accessableHeights.Add('E');

        var level = _mapData[pos.X, pos.Y];
        if (!accessableHeights.Contains(level)) yield break;

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
