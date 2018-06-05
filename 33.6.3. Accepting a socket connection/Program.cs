using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class MainClass
{
    string path = @"c:\TESST\Test.txt";
    const int echoPort = 9050;
    private static void HandleRequest(object state)
    {
       
        using (Socket client = (Socket)state)
        using (NetworkStream stream = new NetworkStream(client))
        using (StreamReader reader = new StreamReader(stream))
        using (StreamWriter writer = new StreamWriter(stream))
        {
            string fileName = reader.ReadLine();
            // writer.Write(File.ReadAllText(path,fileName));
            writer.Write("c:\\TEST\\Test.txt",fileName);
        }
    }
    public static void Main()
    {
        using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
        {
            s.Bind(new IPEndPoint(IPAddress.Loopback, echoPort));
            s.Listen(3);

            Socket client = s.Accept();
            ThreadPool.QueueUserWorkItem(HandleRequest, client);
            Console.WriteLine("Press <enter> to quit");
            Console.ReadLine();
        }
    }
}