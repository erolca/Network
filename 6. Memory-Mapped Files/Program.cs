using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        long offset = 0x10000000; // 256 megabytes
        long length = 0x20000000; // 512 megabytes

        using (var mmf = MemoryMappedFile.CreateFromFile(@"c:\test.data", FileMode.Open, "ImgA"))
        {
            using (var accessor = mmf.CreateViewAccessor(offset, length))
            {
                int colorSize = Marshal.SizeOf(typeof(MyColor));
                MyColor color;
                for (long i = 0; i < length; i += colorSize)
                {
                    accessor.Read(i, out color);
                    accessor.Write(i, ref color);
                }
            }
        }

    }
}
public struct MyColor
{
    public short Red;
}
