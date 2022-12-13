using System.Text;

namespace Day10;

public class CPU
{
    public CPU(int state = 1) => State = state;

    public int State { get; private set; }

    public IEnumerable<int> Noop() 
        => new List<int>(1) { State };

    public IEnumerable<int> Addx(int stateOffset)
    {
        var seq = new List<int>(2) { State, State };
        State += stateOffset;
        return seq;
    }

    public IEnumerable<int> Parse(string instruction)
    {
        if (instruction == "noop") return Noop();

        var split = instruction.Split(' ');
        var offset = int.Parse(split[1]);
        return Addx(offset);
    }

    public List<int> RunProgram(string filename) 
        => new int[] { State }
            .Concat(
                File.ReadLines(filename).SelectMany(Parse))
            .ToList();

    public int FindSignalStrength(string filename)
    {
        var interestingStates = new int[] { 20, 60, 100, 140, 180, 220 };
        var states = RunProgram(filename);
        return interestingStates.Select(s => states[s] * s).Sum();
    }

    public string RenderScreen(string filename)
    {
        var spritePositions = RunProgram(filename);
        var sb = new StringBuilder(260);
        var cycle = 1;
        for (int line = 0; line < 6; ++line)
        {
            for (int col = 1; col < 41; ++col)
            {
                var pos = spritePositions[cycle];
                var sprite = new int[] { pos, pos + 1, pos + 2 };
                var glyph = sprite.Contains(col) ? '#' : '.';
                sb.Append(glyph);
                ++cycle;
            }

            sb.AppendLine();
        }
        return sb.ToString();
    }
}
