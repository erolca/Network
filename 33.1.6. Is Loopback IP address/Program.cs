using System;
using System.Net;

class MainClass
{
    public static void Main()
    {
        IPAddress test2 = IPAddress.Loopback;

        if (IPAddress.IsLoopback(test2))
            Console.WriteLine("The Loopback address is: {0}", test2.ToString());
        else
            Console.WriteLine("Error obtaining the loopback address");

    }
}
//The Loopback address is: 127.0.0.1