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

        test.Blocking = false;
        Console.WriteLine("new Blocking: {0}", test.Blocking);
        Console.WriteLine("Connected: {0}", test.Connected);

        test.Close();
    }
}
//Blocking: True
//new Blocking: False
//Connected: False