using System;
using System.IO;

class MemStreamApp
{
    static void Main(string[] args)
    {
        MemoryStream m = new MemoryStream(64);
        Console.WriteLine("Length: {0}\tPosition: {1}\tCapacity: {2}", m.Length, m.Position, m.Capacity);

        for (int i = 0; i < 64; i++)
        {
            m.WriteByte((byte)i);
        }
        Console.WriteLine("Length: {0}\tPosition: {1}\tCapacity: {2}", m.Length, m.Position, m.Capacity);

        byte[] ba = m.GetBuffer();
        foreach (byte b in ba)
        {
            Console.Write("{0,-3}", b);
        }

        m.Close();
    }
}