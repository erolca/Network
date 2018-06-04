using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class MainClass
{

    const int echoPort = 9050;

    public static void Main()
    {

        /*uygulama 33.4.4 calistir, akabinde bunu...*/
        IPAddress host = IPAddress.Parse("127.0.0.1"/*"192.168.1.1"*/);
        IPEndPoint hostep = new IPEndPoint(host, echoPort);
        Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        try
        {
           // sock.Connect(hostep);
            sock.Connect(new IPEndPoint(IPAddress.Loopback, echoPort));
        }
        catch (SocketException e)
        {
            Console.WriteLine("Problem connecting to host");
            Console.WriteLine(e.ToString());
            sock.Close();
            return;
        }

        sock.Close();
    }
}