using System;
using System.IO;
using System.Net;
using System.Net.Sockets;


//33.7.5.	Create BinaryWriter and BinaryReader from TcpClient

class MainClass
{
    public static void Main()
    {
        TcpClient client = new TcpClient();

        try
        {
            Console.WriteLine("Attempting to connect to the server ", "on port 8000.");
            client.Connect(IPAddress.Parse("127.0.0.1"), 8000);
            Console.WriteLine("Connection established.");

            NetworkStream stream = client.GetStream();

            using (BinaryWriter w = new BinaryWriter(stream))
            {
            }
            using (BinaryReader r = new BinaryReader(stream))
            {
            }

        }
        catch (Exception err)
        {
            Console.WriteLine(err.ToString());
        }
        finally
        {
            client.Close();
            Console.WriteLine("Port closed.");
        }
    }
}