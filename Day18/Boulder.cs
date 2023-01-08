namespace Day18;

public class Boulder
{
    private readonly int[] _axis;

    public Boulder(string description) 
        => _axis = description.Split(',').Select(int.Parse).ToArray();

    public Boulder((int X, int Y, int Z) point) 
        => _axis = new int[] { point.X, point.Y, point.Z };

    /// <summary>
    /// Copy Constructor changing one axis value.
    /// </summary>
    public Boulder(Boulder boulder, Axis axis, int newAxisValue)
    {
        _axis = (int[])boulder._axis.Clone();
        _axis[(int)axis] = newAxisValue;
    }

    public int GetValue(Axis axis) => _axis[(int)axis];

    public (int X, int Y, int Z) ToTuple()
        => (_axis[0], _axis[1], _axis[2]);
}
