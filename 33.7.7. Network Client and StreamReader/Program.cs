using System;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;

public class MainClass
{
    public static void Main()
    {
        int BufferSize = 256;
        TcpClient tcpSocket = new TcpClient("127.0.0.1", 9050);
        NetworkStream streamToServer = tcpSocket.GetStream();
        StreamWriter writer = new StreamWriter(streamToServer);
        writer.Write("message");
        writer.Flush();
        bool fQuit = false;
        while (!fQuit)
        {
            char[] buffer = new char[BufferSize];
            StreamReader reader = new StreamReader(streamToServer);
            int bytesRead = reader.Read(buffer, 0, BufferSize);
            if (bytesRead == 0)
                fQuit = true;
            else
            {
                string theString = new String(buffer);
                Console.WriteLine(theString);
            }
        }
        streamToServer.Close();
    }
}