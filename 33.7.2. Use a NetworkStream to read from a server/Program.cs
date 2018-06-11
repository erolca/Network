using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

class MainClass
{
    public static void Main()
    {
        TcpClient newSocket = new TcpClient("localhost", 9050);

        NetworkStream ns = newSocket.GetStream();
        /**/
        if (ns.CanWrite && ns.CanRead)
        {
            Byte[] sendBytes = Encoding.ASCII.GetBytes("Is anybody there");
            ns.Write(sendBytes, 0, sendBytes.Length);



            
byte[] buf = new byte[100];
            ns.Read(buf, 0, 100);

            char[] buf2 = new char[100];
            for (int i = 0; i < 100; i++)
                buf2[i] = (char)buf[i];
            Console.WriteLine(buf2);
        }




        /**/



      

        ns.Close();
        newSocket.Close();

    }

}