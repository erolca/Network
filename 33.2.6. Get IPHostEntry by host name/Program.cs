using System;
using System.Net;

class MainClass
{
    public static void Main(string[] argv)
    {
        IPHostEntry results = Dns.GetHostByName("www.java2s.com");

        Console.WriteLine("Host name: {0}", results.HostName);

        foreach (string alias in results.Aliases)
        {
            Console.WriteLine("Alias: {0}", alias);
        }
        foreach (IPAddress address in results.AddressList)
        {
            Console.WriteLine("Address: {0}",
                        address.ToString());
        }
    }
}
//Host name: java2s.com
//Alias: www.java2s.com
//Address: 68.178.206.138