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
        NBTValue byteValue = (byte)252;
        NBTValue boolValue = true;
        NBTValue shortValue = (short)75;
        NBTValue intValue = 123;
        NBTValue longValue = 356L;
        NBTValue floatValue = 20.0f;
        NBTValue doubleValue = 15.0d;
        NBTValue stringValue = "\'\'LuviKunG\"\"";
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
        NBTCompound compound = new() { { "a", 1 }, { "b", 2 } };
        NBTList list = new()
        {
            (byte)252,
            true,
            (short)75,
            123,
            356L,
            20.0f,
            15.0d,
            "\'\'LuviKunG\"\""
        };
        Console.WriteLine(compound);
        Console.WriteLine(NBTParser.Parse(compound));
        Console.WriteLine(list);
        Console.WriteLine(NBTParser.Parse(list));
        return 0;
    }
}