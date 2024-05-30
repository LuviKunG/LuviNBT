using NBT;
using NBT.Parser;

static class Program
{
    /// <summary>
    /// Entry point for console.
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
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
        // Print the values.
        Console.WriteLine(byteValue);
        Console.WriteLine(boolValue);
        Console.WriteLine(shortValue);
        Console.WriteLine(intValue);
        Console.WriteLine(longValue);
        Console.WriteLine(floatValue);
        Console.WriteLine(doubleValue);
        Console.WriteLine(stringValue);

        // Example code to create NBT Compound and list.
        NBTCompound compound = new()
        {
            {"test1", 123},
            {"test2", (short)456}
        };
        compound.Add("test3", (long)789);
        NBTList list = new()
        {
            123,
            (short)456
        };
        list.Add((long)789);
        Console.WriteLine(compound);
        Console.WriteLine(NBTParser.Parse(compound));
        Console.WriteLine(list);
        Console.WriteLine(NBTParser.Parse(list));
        return 0;
    }
}