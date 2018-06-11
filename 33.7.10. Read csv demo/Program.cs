using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;


//33.7.10.	Read csv from finance.yahoo.com with TcpClient

public class MainClass
{
    public static void Main()
    {
        String ticker = "MSFT";
        String url = "/d/quotes.csv?s=" + ticker + "&f=sl1d1t1c1ohgv&e=.csv";
        TcpClient sock = new TcpClient("finance.yahoo.com", 80);
        Stream stream = sock.GetStream();
        Byte[] req = Encoding.ASCII.GetBytes("GET " + url + " HTTP/1.0\n\n");
        stream.Write(req, 0, req.Length);
        stream.Flush();
        StreamReader inp = new StreamReader(stream);
        String line;
        while ((line = inp.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
        inp.Close();
    }
}