namespace Day7;

public class SystemDirectory
{
    private Dictionary<string, SystemDirectory> _directories = new();
    private int _size = 0;

    public SystemDirectory(string name) => Name = name;

    public string Name { get; }

    public int Size => _size;

    public void AddFile(int size) => _size += size;

    public void AddDirectory(string name) 
        => _directories[name] = new SystemDirectory(name);

    public SystemDirectory MoveIn(string subDirectoryName)
    {
        if (!_directories.ContainsKey(subDirectoryName))
            throw new InvalidOperationException($"Directory not found: {subDirectoryName}");

        return _directories[subDirectoryName];
    }

    public void MoveOut()
    {
        throw new InvalidOperationException($"No parent directory");
    }
}
