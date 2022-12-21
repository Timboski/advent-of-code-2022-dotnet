namespace Day13;

public static class DecoderKey
{
    public static int Find(string filename)
    {
        // Add packets to a list
        var twoDivider = new ArrayElement("[[2]]");
        var sixDivider = new ArrayElement("[[6]]");
        var packets = File.ReadAllLines(filename)
            .Where(line => !string.IsNullOrEmpty(line))
            .Select(x => new ArrayElement(x))
            .ToList();
        packets.Add(twoDivider);
        packets.Add(sixDivider);

        // Sort them
        static int CompareArrays(ArrayElement left, ArrayElement right)
            => (int)left.CheckOrder(right);
        packets.Sort(CompareArrays);

        // Find the dividers
        var twoPos = packets.IndexOf(twoDivider) + 1;
        var sixPos = packets.IndexOf(sixDivider) + 1;

        // Multiply
        return twoPos * sixPos;
    }
}
