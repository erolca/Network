using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Usage: DnsLookup hostname/IP Adddress");
            return;
        }

        IPHostEntry ipHostEntry = Dns.GetHostEntry(args[0]);

        Console.WriteLine("Host: {0}", ipHostEntry.HostName);

        if (ipHostEntry.Aliases.Length > 0)
        {
            Console.WriteLine("\nAliases:");
            foreach (string alias in ipHostEntry.Aliases)
            {
                Console.WriteLine(alias);
            }
        }

        Console.WriteLine("\nAddress(es):");
        foreach (IPAddress address in ipHostEntry.AddressList)
        {
            Console.WriteLine("Address: {0}", address.ToString());
        }

    }
}