using System;
using System.IO;

//Use MemoryStream and BinaryWriter to convert decimal to byte array

class Test
{

    const string fileName = "AppSettings.dat";

    // Create a byte array from a decimal.
    public static byte[] DecimalToByteArray(decimal src)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write(src);// write to in memorystream
                return stream.ToArray();
            }
        }
    }
    public static void Main()
    {
        byte[] b = DecimalToByteArray(285998345545.563846696m);
        // Convert a decimal to a byte array and display.
        Console.WriteLine(BitConverter.ToString(b));


      
        WriteDefaultValues();
        DisplayValues();
    }

    public static void WriteDefaultValues()
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
        {
            writer.Write(1.250F);
            writer.Write(@"c:\Temp");
            writer.Write(10);
            writer.Write(true);
        }
    }

    public static void DisplayValues()
    {
        float aspectRatio;
        string tempDirectory;
        int autoSaveTime;
        bool showStatusBar;

        if (File.Exists(fileName))
        {
            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                aspectRatio = reader.ReadSingle();
                tempDirectory = reader.ReadString();
                autoSaveTime = reader.ReadInt32();
                showStatusBar = reader.ReadBoolean();
            }

            Console.WriteLine("Aspect ratio set to: " + aspectRatio);
            Console.WriteLine("Temp directory is: " + tempDirectory);
            Console.WriteLine("Auto save time set to: " + autoSaveTime);
            Console.WriteLine("Show status bar: " + showStatusBar);
        }
    }
}