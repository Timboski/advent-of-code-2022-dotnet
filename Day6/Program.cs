using Day6;

var data = File.ReadAllText("day6-input.txt");
var packetStart = DataStreamDecoder.FindStartOfPacket(data);
Console.WriteLine($"Part 1: {packetStart}");

var messageStart = DataStreamDecoder.FindStartOfMessage(data);
Console.WriteLine($"Part 2: {messageStart}");