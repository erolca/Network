using System;
using System.Net;

class MainClass
{
    public static void Main()
    {
        string hostName = Dns.GetHostName();
        Console.WriteLine("Local hostname: {0}", hostName);
        IPHostEntry myself = Dns.GetHostByName(hostName);
        foreach (IPAddress address in myself.AddressList)
        {
            Console.WriteLine("IP Address: {0}", address.ToString());
        }
    }
}
//Local hostname: java2s
//IP Address: 192.168.1.101