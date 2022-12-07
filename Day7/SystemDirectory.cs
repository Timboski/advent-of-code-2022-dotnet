namespace Day7;

public class SystemDirectory
{
    private readonly Dictionary<string, SystemDirectory> _children = new();
    private int _size = 0;
    private readonly SystemDirectory? _parent = null;

    public SystemDirectory() => Name = "/";

    private SystemDirectory(string name, SystemDirectory parent)
    {
        Name = name;
        _parent = parent;
    }

    public string Name { get; }

    public int Size 
        => _children.Values.Select(c => c.Size).Sum() + _size;

    public void AddFile(int size) => _size += size;

    public SystemDirectory MoveIn(string subDirectoryName)
    {
        if (_children.TryGetValue(subDirectoryName, out SystemDirectory? value)) return value;
        return _children[subDirectoryName] = new SystemDirectory(subDirectoryName, this);
    }

    public SystemDirectory MoveOut() 
        => _parent ?? throw new InvalidOperationException($"No parent directory");

    public bool IsChild(string subDirectoryName) 
        => _children.ContainsKey(subDirectoryName);
}
