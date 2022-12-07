namespace Day7;

public class TerminalOutputDecoder
{
    private readonly ISystemDirectory _root;
    private ISystemDirectory _current;

    public TerminalOutputDecoder(ISystemDirectory root)
    {
        _root = root;
        _current = root;
    }

    public void ProcessLine(string line)
    {
        var sections = line.Split(' ');
        if (sections[1] == "cd") _current = _current.MoveIn(sections[2]);
    }
}
