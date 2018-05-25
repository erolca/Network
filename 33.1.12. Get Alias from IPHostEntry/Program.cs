using System;
using System.Net;

class MainClass
{
    public static void Main(string[] argv)
    {
        IPAddress test = IPAddress.Parse("64.200.123.1");

        IPHostEntry iphe = Dns.GetHostByAddress(test);

        foreach (string alias in iphe.Aliases)
        {
            Console.WriteLine("Alias: {0}", alias);
        }
    }
}