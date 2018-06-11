using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.IO;
using System.Text;

//33.7.8.	Network Client with TcpClient and NetworkStream

public class AsynchNetworkClient
{
    public static void Main()
    {

        TcpClient tcpSocket = new TcpClient("127.0.0.1", 9050);
        NetworkStream streamToServer = tcpSocket.GetStream();

        StreamWriter writer = new StreamWriter(streamToServer);
        writer.WriteLine("Hello Programming C#");
        writer.Flush();

        StreamReader reader = new StreamReader(streamToServer);
        string strResponse = reader.ReadLine();
        Console.WriteLine("Received: {0}", strResponse);
        streamToServer.Close();
    }
}