using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class MainClass
{
    public static void Main()
    {
        TcpListener client = new TcpListener(9050);
        client.Start();

        Console.WriteLine("Waiting for clients...");
        while (true)
        {
            while (!client.Pending())
            {
                Thread.Sleep(1000);
            }
            ConnectionThread newconnection = new ConnectionThread(client);
        }
    }
}

class ConnectionThread
{
    public TcpListener threadListener;

    public ConnectionThread(TcpListener lis)
    {
        threadListener = lis;
        ThreadPool.QueueUserWorkItem(new WaitCallback(HandleConnection));

    }

    public void HandleConnection(object state)
    {
        int recv;
        byte[] data = new byte[1024];

        TcpClient client = threadListener.AcceptTcpClient();
        NetworkStream ns = client.GetStream();

        string welcome = "Welcome";
        data = Encoding.ASCII.GetBytes(welcome);
        ns.Write(data, 0, data.Length);

        while (true)
        {
            data = new byte[1024];
            recv = ns.Read(data, 0, data.Length);
            ns.Write(data, 0, recv);
        }
        ns.Close();
        client.Close();
    }
}