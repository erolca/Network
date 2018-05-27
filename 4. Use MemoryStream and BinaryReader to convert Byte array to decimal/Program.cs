using System;
using System.IO;

//Use MemoryStream and BinaryReader to convert Byte array to decimal

class Test
{
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

    public static decimal ByteArrayToDecimal(byte[] src)
    {
        using (MemoryStream stream = new MemoryStream(src))
        {
            using (BinaryReader reader = new BinaryReader(stream))
            {
                return reader.ReadDecimal();
            }
        }
    }

    public static void Main()
    {
        byte[] b = BitConverter.GetBytes(true);
      
       

        // Convert a decimal to a byte array and display.
        b = DecimalToByteArray(12345678987654321.563846696m);
        Console.WriteLine(BitConverter.ToString(b));

        // Convert a byte array to a decimal and display.
        Console.WriteLine(ByteArrayToDecimal(b));


        /**/
        byte[] b1 = BitConverter.GetBytes(255);
        byte[] b2 = BitConverter.GetBytes(44.23);
        byte[] b3 = BitConverter.GetBytes(0x25FF63);

    }
}
