using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

//33.1.10.	Serialize a SocketAddress from a IPEndPoint
class MainClass
{
    public static void Main()
    {
        IPAddress test1 = IPAddress.Parse("192.168.1.1");
        IPEndPoint ie = new IPEndPoint(test1, 8000);
        ie.Port = 8000;
        SocketAddress sa = ie.Serialize();
        Console.WriteLine("The SocketAddress is: {0}", sa.ToString());

    }
}
//The SocketAddress is: InterNetwork:16:{31,64,192,168,1,1,0,0,0,0,0,0,0,0}