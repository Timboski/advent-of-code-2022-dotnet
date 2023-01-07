namespace Day18;

public class Boulder
{
    private readonly int[] _axis;

    public Boulder(string description) 
        => _axis = description.Split(',').Select(int.Parse).ToArray();

    public int GetValue(Axis axis) => _axis[(int)axis];
}
