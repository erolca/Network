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
        byte[] value = WriteDefaultValues();
        DisplayValues(value);


        /**/
        byte[] b1 = BitConverter.GetBytes(255);
        byte[] b2 = BitConverter.GetBytes(44.23);
        byte[] b3 = BitConverter.GetBytes(0x25FF63);

    }


    public static byte[] WriteDefaultValues()
    {
        using (MemoryStream stream = new MemoryStream())
        {
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write(1.250F);
                writer.Write(@"c:\Temp");
                writer.Write(10);
                writer.Write(true);
                return stream.ToArray();
            }
        }
    }

    public static void DisplayValues(byte[] src)
    {
        float aspectRatio;
        string tempDirectory;
        int autoSaveTime;
        bool showStatusBar;

        using (MemoryStream stream = new MemoryStream(src))
        {
            using (BinaryReader reader = new BinaryReader(stream))
            {
                aspectRatio = reader.ReadSingle();
                tempDirectory = reader.ReadString();
                autoSaveTime = reader.ReadInt32();
                showStatusBar = reader.ReadBoolean();
            }
        }

            Console.WriteLine("Aspect ratio set to: " + aspectRatio);
            Console.WriteLine("Temp directory is: " + tempDirectory);
            Console.WriteLine("Auto save time set to: " + autoSaveTime);
            Console.WriteLine("Show status bar: " + showStatusBar);
        
    }




}
