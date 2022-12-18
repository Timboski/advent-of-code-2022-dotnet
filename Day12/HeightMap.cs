﻿using System.Text;

namespace Day12;

public class HeightMap
{
    private readonly char _startHeight;
    private readonly char[,] _mapData;
    private readonly int _startX = -1;
    private readonly int _startY = -1;

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

                if (glyph == 'S')
                {
                    _startX = x;
                    _startY = y;
                }

                if (glyph == 'E') IsComplete = false;
            }
        }

        if (_startX < 0) throw new NoStartException();
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

    public bool IsComplete { get; } = true;

    public int XSize { get; }

    public int YSize { get; }

    public int PathLength => CountVisitedElements();

    public List<HeightMap> FindSteps() 
        => new[] {
                (_startX, _startY - 1),
                (_startX, _startY + 1),
                (_startX - 1, _startY),
                (_startX + 1, _startY),
            }
            .SelectMany(pos => CheckLocation(pos.Item1, pos.Item2))
            .ToList();

    private IEnumerable<HeightMap> CheckLocation(int x, int y)
    {
        if (x < 0) yield break;
        if (x >= XSize) yield break;
        if (y < 0) yield break;
        if (y >= YSize) yield break;

        var accessableHeights = new List<char>() 
            { (char)(_startHeight - 1), _startHeight, (char)(_startHeight + 1) };
        if (_startHeight >= 'y') accessableHeights.Add('E');

        var level = _mapData[x, y];
        if (!accessableHeights.Contains(level)) yield break;

        var newMap = (char[,])_mapData.Clone();
        newMap[_startX, _startY] = '#';
        newMap[x, y] = 'S';
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
