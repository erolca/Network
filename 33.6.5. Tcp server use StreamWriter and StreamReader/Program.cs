using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

class MainClass
{
    public static void Main()
    {
        string data;
        IPEndPoint ip = new IPEndPoint(IPAddress.Any, 9050);

        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        socket.Bind(ip);
        socket.Listen(10);

        Socket client = socket.Accept();
        IPEndPoint newclient = (IPEndPoint)client.RemoteEndPoint;
        Console.WriteLine("Connected with {0} at port {1}", newclient.Address, newclient.Port);

        NetworkStream ns = new NetworkStream(client);
        StreamReader sr = new StreamReader(ns);
        StreamWriter sw = new StreamWriter(ns);

        string welcome = "Welcome";
        sw.WriteLine(welcome);
        sw.Flush();

        while (true)
        {
            data = sr.ReadLine();
            Console.WriteLine(data);
            sw.WriteLine(data);
            sw.Flush();
        }
        Console.WriteLine("Disconnected from {0}", newclient.Address);
        sw.Close();
        sr.Close();
        ns.Close();
    }
}