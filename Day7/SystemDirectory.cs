namespace Day7;

public class SystemDirectory
{
    private Dictionary<string, SystemDirectory> _directories = new();
    private int _size = 0;
    private readonly SystemDirectory? _parent = null;

    public SystemDirectory() => Name = "/";

    public SystemDirectory(string name, SystemDirectory parent)
    {
        Name = name;
        _parent = parent;
    }

    public string Name { get; }

    public int Size => _size;

    public void AddFile(int size) => _size += size;

    public void AddDirectory(string name) 
        => _directories[name] = new SystemDirectory(name, this);

    public SystemDirectory MoveIn(string subDirectoryName)
    {
        if (!_directories.ContainsKey(subDirectoryName))
            throw new InvalidOperationException($"Directory not found: {subDirectoryName}");

        return _directories[subDirectoryName];
    }

    public SystemDirectory MoveOut() 
        => _parent ?? throw new InvalidOperationException($"No parent directory");
}
