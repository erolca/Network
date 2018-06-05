using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class MainClass
{
    const int echoPort = 9050;
    public static void Main()
    {
        IPEndPoint ip = new IPEndPoint(IPAddress.Any, echoPort);
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        socket.Bind(ip);
        socket.Listen(10);
        Console.WriteLine("Waiting for a client...");
        Socket client = socket.Accept();
        IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;
        Console.WriteLine("Connected with {0} at port {1}", clientep.Address, clientep.Port);

        string welcome = "Welcome";
        byte[] data = new byte[1024];
        data = Encoding.ASCII.GetBytes(welcome);
        client.Send(data, data.Length, SocketFlags.None);

        while (true)
        {
            data = new byte[1024];
            int receivedDataLength = client.Receive(data);
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, receivedDataLength));
            client.Send(data, receivedDataLength, SocketFlags.None);
           if (client.Connected)
            {

                Console.WriteLine("Connected");
            }

             
        }

        Console.WriteLine("Disconnected from {0}", clientep.Address);
        client.Close();
        socket.Close();
    }
}