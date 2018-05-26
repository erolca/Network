using System;
using System.IO;

public class MemTest
{
    public static void Main()
    {
        MemoryStream memOut = new MemoryStream();

        byte[] bs = { 1, 2, 3, 4, 5, 6 };
        memOut.Write(bs, 0, bs.Length);

        memOut.Seek(+3, SeekOrigin.Begin);
        byte b = (byte)memOut.ReadByte();
        Console.WriteLine("Value: " + b);
    }
}
