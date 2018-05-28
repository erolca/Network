using System;
using System.Net;

class MainClass
{
    public static void Main(string[] argv)
    {
        IPAddress test = IPAddress.Parse("192.168.1.1");

        IPHostEntry iphe = Dns.GetHostByAddress(test);
        Console.WriteLine(iphe.HostName);

        foreach (IPAddress address in iphe.AddressList)
        {
            Console.WriteLine("Address: {0}", address.ToString());
        }
    }
}
