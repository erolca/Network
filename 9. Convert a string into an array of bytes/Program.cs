using System;
using System.IO;
using System.Text;

public static class CompressionUtility
{
    /// <summary>
    /// Convert a string into an array of bytes
    /// </summary>
    /// <param name="input">String to convert</param>
    /// <returns>Byte atray that repsesents the string</returns>
    public static byte[] ConvertStringToBytes(string input)
    {
        MemoryStream stream = new MemoryStream();
        using (StreamWriter writer = new StreamWriter(stream))
        {
            writer.Write(input);
            writer.Flush();
        }
        return stream.ToArray();
    }

}

class MyClass
{
    public static void Main()
    {


    }
}