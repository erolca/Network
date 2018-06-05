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
    TcpListener threadListener;
    int recv;

    public ConnectionThread(TcpListener lis)
    {
        threadListener = lis;
        Thread newthread = new Thread(new ThreadStart(HandleConnection));
        newthread.Start();
    }

    public void HandleConnection()
    {
        byte[] data = new byte[1024];
       

        TcpClient client = threadListener.AcceptTcpClient();
        NetworkStream ns = client.GetStream();

        string welcome = "Welcome to my world";
        data = Encoding.ASCII.GetBytes(welcome);
        ns.Write(data, 0, data.Length);

        while (true)
        {
            data = new byte[1024];
            try
            {
                 recv = ns.Read(data, 0, data.Length);

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                break;

            }
            
            if (recv == 0)
                break;
            ns.Write(data, 0, recv);
        }
        ns.Close();
        client.Close();
    }
}