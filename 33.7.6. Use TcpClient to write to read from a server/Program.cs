using System;
using System.Net;
using System.Net.Sockets;
using System.IO;

public class MainClass
{
    private static void Main()
    {
        using (TcpClient client = new TcpClient())
        {
            Console.WriteLine("Attempting to connect to the server ", "on port 8000.");

            client.Connect(IPAddress.Parse("127.0.0.1"), 9050);

            using (NetworkStream networkStream = client.GetStream())
            {
                using (BinaryWriter writer = new BinaryWriter(networkStream))
                {
                    writer.Write("info");

                    using (BinaryReader reader = new BinaryReader(networkStream))
                    {
                        Console.WriteLine(reader.ReadString());
                    }
                }
            }
        }
    }
}