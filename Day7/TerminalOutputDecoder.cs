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
        if (sections[1] == "cd")
        {
            var target = sections[2];
            _current = target switch
            {
                "/" => _root,
                ".." => _current.MoveOut(),
                _ => _current.MoveIn(target),
            };
            return;
        }
        if (int.TryParse(sections[0], out var fileSize)) 
        {
            _current.AddFile(fileSize);
            return;
        }
    }
}
