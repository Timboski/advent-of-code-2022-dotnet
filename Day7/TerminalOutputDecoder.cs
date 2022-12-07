namespace Day7;

public class TerminalOutputDecoder
{
    private readonly ISystemDirectory _root;

    public TerminalOutputDecoder(ISystemDirectory root)
    {
        _root = root;
    }

    public void ProcessLine(string line)
    {
        var sections = line.Split(' ');
        if (sections[1] == "cd") _root.MoveIn(sections[2]);
    }
}
