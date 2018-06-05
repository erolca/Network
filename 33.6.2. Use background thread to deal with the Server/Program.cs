using System;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

public class MainClass
{
    private const int CONNECT_QUEUE_LENGTH = 4;
    const int echoPort = 9050;
    static void ListenForRequests()
    {
        Socket listenSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        listenSock.Bind(new IPEndPoint(IPAddress.Any, echoPort));
        listenSock.Listen(CONNECT_QUEUE_LENGTH);

        while (true)
        {
            Socket newConnection = listenSock.Accept();
            byte[] msg = Encoding.UTF8.GetBytes("Hello!");
            newConnection.BeginSend(msg, 0, msg.Length, SocketFlags.None, null, null);
        }
    }

    static void Main()
    {
        Thread listener = new Thread(new ThreadStart(ListenForRequests));
        listener.IsBackground = true;
        listener.Start();

        Console.WriteLine("Press <enter> to quit");
        Console.ReadLine();
    }
}