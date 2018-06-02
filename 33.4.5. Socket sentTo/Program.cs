using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class MultiSend
{
    public static void Main()
    {
        //Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);

        byte[] data = Encoding.ASCII.GetBytes("This is a test message");
        server.SendTo(data, iep);
        server.Close();
    }
}