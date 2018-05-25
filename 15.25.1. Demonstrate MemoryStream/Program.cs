using System;
using System.IO;

class MainClass
{
    public static void Main()
    {
        byte[] storage = new byte[255];

        MemoryStream memstrm = new MemoryStream(storage);

        StreamWriter memwtr = new StreamWriter(memstrm);
        StreamReader memrdr = new StreamReader(memstrm);

        for (int i = 0; i < 10; i++)
            memwtr.WriteLine("byte [" + i + "]: " + i);

        memwtr.WriteLine(".");

        memwtr.Flush();

        Console.WriteLine("Reading from storage directly: ");

        foreach (char ch in storage)
        {
            if (ch == '.') break;
            Console.Write(ch);
        }

        Console.WriteLine("\nReading through memrdr: ");

        memstrm.Seek(0, SeekOrigin.Begin); // reset file pointer  

        string str = memrdr.ReadLine();
        while (str != null)
        {
            Console.WriteLine(str);
            str = memrdr.ReadLine();
            if (str.CompareTo(".") == 0) break;
        }
    }
}