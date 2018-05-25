using System;
using System.Net;

class MainClass
{
    public static void Main()
    {
        string hostName = Dns.GetHostName();
        IPHostEntry ihe = Dns.GetHostByName(Dns.GetHostName());
        //IPHostEntry ihe = Dns.GetHostByName(hostName);
        IPAddress myself = ihe.AddressList[0];

        Console.WriteLine(myself);
    }
}
//192.168.1.101