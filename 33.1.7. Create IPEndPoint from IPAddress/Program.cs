using System;
using System.Net;


class MainClass
{
    public static void Main()
    {
        IPAddress test1 = IPAddress.Parse("192.168.1.1");
        IPEndPoint ie = new IPEndPoint(test1, 8000);

        Console.WriteLine("The IPEndPoint is: {0}", ie.ToString());
        Console.WriteLine("The AddressFamily is: {0}", ie.AddressFamily);
        Console.WriteLine("The address is: {0}, and the port is: {1}", ie.Address, ie.Port);

    }
}
//The IPEndPoint is: 192.168.1.1:8000
//The AddressFamily is: InterNetwork
//The address is: 192.168.1.1, and the port is: 8000