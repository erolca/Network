using System;
using System.IO;

//Use MemoryStream and BinaryWriter to convert decimal to byte array

class Test
{
    // Create a byte array from a decimal.
    public static byte[] DecimalToByteArray(decimal src)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write(src);
                return stream.ToArray();
            }
        }
    }
    public static void Main()
    {
        byte[] b = DecimalToByteArray(285998345545.563846696m);
        // Convert a decimal to a byte array and display.
        Console.WriteLine(BitConverter.ToString(b));
    }
}