using System;
using System.Drawing;
using System.Net;
using System.Text;
//using System.Windows.Forms;

class MainClass
{
    private static void Resolved(IAsyncResult ar)
    {
        string buffer;

        IPHostEntry iphe = Dns.EndResolve(ar);

        buffer = "Host name: " + iphe.HostName;
        Console.WriteLine(buffer);

        foreach (string alias in iphe.Aliases)
        {
            buffer = "Alias: " + alias;
            Console.WriteLine(buffer);
        }
        for (int i = 0; i < iphe.AddressList.Length; i++)
        {
            IPAddress addrs = iphe.AddressList[i];
            buffer = "Address: " + addrs.ToString();
            Console.WriteLine(buffer);
        }
    }

    public static void Main()
    {
        AsyncCallback OnResolved;

        OnResolved = new AsyncCallback(Resolved);

        string addr = "www.java2s.com";
        Object state = new Object();

        Dns.BeginResolve(addr, OnResolved, state);
    }
}