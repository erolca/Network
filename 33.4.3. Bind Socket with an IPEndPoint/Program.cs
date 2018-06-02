using System;
using System.Net;
using System.Net.Sockets;

class MainClass
{
    public static void Main()
    {
        IPAddress ia = IPAddress.Parse("127.0.0.1");
        IPEndPoint ie = new IPEndPoint(ia, 8000);

        Socket test = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        Console.WriteLine("Blocking: {0}", test.Blocking);

        test.Bind(ie);
        IPEndPoint iep = (IPEndPoint)test.LocalEndPoint;
        Console.WriteLine("Local EndPoint: {0}", iep.ToString());

        test.Close();
    }
}
//Blocking: True
//Local EndPoint: 127.0.0.1:8000