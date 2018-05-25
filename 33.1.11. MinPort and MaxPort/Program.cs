using System;
using System.Net;

//33.1.11.	IPEndPoint: MinPort and MaxPort
class MainClass
{
    public static void Main()
    {
        Console.WriteLine("The min port number is: {0}", IPEndPoint.MinPort);
        Console.WriteLine("The max port number is: {0}\n", IPEndPoint.MaxPort);
    }
}
//The min port number is: 0
//The max port number is: 65535