using System;
using System.Net;

class MainClass
{
    public static void Main(string[] argv)
    {
        IPHostEntry iphe = Dns.Resolve("88.246.98.108");

        Console.WriteLine("Host name: {0}", iphe.HostName);
        foreach (string alias in iphe.Aliases)
        {
            Console.WriteLine("Alias: {0}", alias);
        }
        foreach (IPAddress address in iphe.AddressList)
        {
            Console.WriteLine("Address: {0}",
                        address.ToString());
        }
    }
}
//Host name: 62.208.12.1
//Address: 62.208.12.1