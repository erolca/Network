using System;
using System.Net;
using System.IO;
using System.Text;


class MainClass
{
    public static void Main(string[] args)
    {
        Uri uri = new Uri("http://www.java2s.com");


        WebRequest req = WebRequest.Create(uri);
        WebResponse resp = req.GetResponse();
        Stream stream = resp.GetResponseStream();
        StreamReader sr = new StreamReader(stream);

        string s = sr.ReadToEnd();

        Console.WriteLine(s);

    }
}