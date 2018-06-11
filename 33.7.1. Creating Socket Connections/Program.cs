using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class MainClass
{
    [STAThread]
    static void Main(string[] args)
    {
        TcpClient MyClient = new TcpClient();
        MyClient.Connect("localhost", 9050);
        NetworkStream MyNetStream = MyClient.GetStream();

        if (MyNetStream.CanWrite && MyNetStream.CanRead)
        {
            Byte[] sendBytes = Encoding.ASCII.GetBytes("Is anybody there");
            MyNetStream.Write(sendBytes, 0, sendBytes.Length);

            byte[] bytes = new byte[MyClient.ReceiveBufferSize];
            MyNetStream.Read(bytes, 0, (int)MyClient.ReceiveBufferSize);

            string returndata = Encoding.ASCII.GetString(bytes);
            Console.WriteLine("This is what the host returned to you: " + returndata);
        }
        else if (!MyNetStream.CanRead)
        {
            Console.WriteLine("You can not write data to this stream");
            MyClient.Close();
        }
        else if (!MyNetStream.CanWrite)
        {
            Console.WriteLine("You can not read data from this stream");
            MyClient.Close();
        }
    }
}