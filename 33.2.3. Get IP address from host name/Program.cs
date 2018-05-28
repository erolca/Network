using System;
using System.Net;

class MainClass
{
    public static void Main()
    {
        string hostName = Dns.GetHostName();
       // IPHostEntry ihe = Dns.GetHostByName(Dns.GetHostName());
        //IPHostEntry ihe = Dns.GetHostByName(hostName);
        IPHostEntry ihe = Dns.GetHostByName("NrmAutomation");



        foreach (IPAddress address in ihe.AddressList)
        {
            Console.WriteLine("Address: {0}",  address.ToString());
        }


        IPAddress myself = ihe.AddressList[0];
        Console.WriteLine(myself);
    }
}
//192.168.1.101