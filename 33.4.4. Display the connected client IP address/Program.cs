using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

class MainClass
{
    public static void Main()
    {
        
       //string data;
        // IPEndPoint ip = new IPEndPoint(IPAddress.Any, 9999);
        Console.WriteLine("Hello, 22");
       
        IPAddress ia = IPAddress.Parse("127.0.0.1");
        IPEndPoint ip = new IPEndPoint(ia, 9050);

        //Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        socket.Bind(ip);
        socket.Listen(22);

        Socket client = socket.Accept();
        IPEndPoint newclient = (IPEndPoint)client.RemoteEndPoint;
        Console.WriteLine("Connected with {0} at port {1}", newclient.Address, newclient.Port);


        byte[] data = Encoding.ASCII.GetBytes("This is a test message");
        Console.WriteLine("Disconnected from {0}", newclient.Address);
        client.SendTo(data, newclient);
        client.Close();
       // socket.Close();




        Console.ReadKey();
      


    }
}