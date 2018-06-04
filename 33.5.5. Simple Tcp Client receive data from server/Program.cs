using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class MainClass
{
    const int echoPort = 9050;
    public static void Main()
    {
        IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), echoPort);

        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        try
        {
            server.Connect(ip);
        }
        catch (SocketException e)
        {
            Console.WriteLine("Unable to connect to server.");
            return;
        }

        byte[] data = new byte[1024];
        int receivedDataLength = server.Receive(data);
        string stringData = Encoding.ASCII.GetString(data, 0, receivedDataLength);
        Console.WriteLine(stringData);

        server.Shutdown(SocketShutdown.Both);
        server.Close();
    }
}