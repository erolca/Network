using System;
using System.Net;

class MainClass
{
    public static void Main(string[] argv)
    {
        IPAddress test = IPAddress.Parse("88.246.98.108");

        IPHostEntry iphe = Dns.GetHostByAddress(test);

        Console.WriteLine("Information for {0}", test.ToString());
        Console.WriteLine();

        Console.WriteLine("Host name: {0}", iphe.HostName);
    }
}
//Information for 64.200.123.1
//Host name: drvlga1wct1-atm1-0-0-12.wcg.net