using NBT;
using NBT.Parser;

static class Program
{
    static int Main(string[] args)
    {
        // Example code to create NBT values.
        NBTValue byteValue = new((byte)252);
        NBTValue boolValue = new(true);
        NBTValue shortValue = new((short)75);
        NBTValue intValue = new(123);
        NBTValue longValue = new(356L);
        NBTValue floatValue = new(20.0f);
        NBTValue doubleValue = new(15.0d);
        NBTValue stringValue = new("\'\'LuviKunG\"\"");
        NBTCompound compound = new()
        {
            {"test1", new NBTValue(123)},
            {"test2", new NBTValue((short)456)}
        };
        // Print the values.
        Console.WriteLine(byteValue);
        Console.WriteLine(boolValue);
        Console.WriteLine(shortValue);
        Console.WriteLine(intValue);
        Console.WriteLine(longValue);
        Console.WriteLine(floatValue);
        Console.WriteLine(doubleValue);
        Console.WriteLine(stringValue);
        Console.WriteLine(NBTParser.Parse(compound));
        return 0;
    }
}