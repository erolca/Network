using System;
using System.Net;

class MainClass
{
    public static void Main()
    {

        Uri sample = new Uri("http://www.yoursite.com/somefile.txt?SomeQuery");

        Console.WriteLine("Host: " + sample.Host);
        Console.WriteLine("Port: " + sample.Port);
        Console.WriteLine("Scheme: " + sample.Scheme);
        Console.WriteLine("Local Path: " + sample.LocalPath);
        Console.WriteLine("Query: " + sample.Query);
        Console.WriteLine("Path and query: " + sample.PathAndQuery);

    }
}
//Host: www.yoursite.com
//Port: 80
//Scheme: http
//Local Path: /somefile.txt
//Query: ? SomeQuery
//Path and query: /somefile.txt? SomeQuery