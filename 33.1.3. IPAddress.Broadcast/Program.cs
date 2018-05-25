using System;
using System.Net;

class MainClass
{
    public static void Main()
    {
        IPAddress test = IPAddress.Broadcast;

        Console.WriteLine(test);
    }
}
//255.255.255.255