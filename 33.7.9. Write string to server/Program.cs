using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;


public class MainClass
{
    public static int Main()
    {

        string serverName = "localhost";
        Console.WriteLine("Connecting to {0}", serverName);
        TcpClient tcpSocket = new TcpClient(serverName, 9050);
        NetworkStream streamToServer = tcpSocket.GetStream();
        string message = "Hello";
        Console.WriteLine("Sending {0} to server.", message);
        System.IO.StreamWriter writer = new System.IO.StreamWriter(streamToServer);
        writer.WriteLine(message);
        writer.Flush();
        System.IO.StreamReader reader = new System.IO.StreamReader(streamToServer);
        string strResponse = reader.ReadLine();
        Console.WriteLine("Received: {0}", strResponse);
        streamToServer.Close();
        return 0;
    }
}