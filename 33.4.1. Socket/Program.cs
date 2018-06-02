using System;
using System.Net;
using System.Net.Sockets;


//Socket: AddressFamily, SocketType and ProtocolType

class MainClass
{
    public static void Main()
    {
        IPAddress ia = IPAddress.Parse("127.0.0.1");
        IPEndPoint ie = new IPEndPoint(ia, 8000);


        //Socket sınıfının bu kurucu işlevi parametre olarak AdressFamily dedigimiz adresleme şemasi
        //SocketType ve kullanacagimiz protokol tipini alir. 
        //Bu 3 paremtere de .NET Framework class kütüphanesinde Enum sabitleri olarak tanimlanmistir.
        Socket test = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        Console.WriteLine("AddressFamily: {0}", test.AddressFamily);
        Console.WriteLine("SocketType: {0}", test.SocketType);
        Console.WriteLine("ProtocolType: {0}", test.ProtocolType);


        test.Close();
    }
}
//AddressFamily: InterNetwork
//SocketType: Stream
//ProtocolType: Tcp