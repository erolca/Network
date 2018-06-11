using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

class MainClass
{
    public static void Main()
    {
        TcpClient client = new TcpClient();
      
        try
        {
            Console.WriteLine("Attempting to connect to the server ", "on port 9050.");
            client.Connect("localhost", 9050);
           // client.Connect(IPAddress.Parse("127.0.0.1"), 9050);
            Console.WriteLine("Connection established.");
           

            NetworkStream stream = client.GetStream();
            if (stream.CanWrite )
            {
                BinaryWriter w = new BinaryWriter(stream);
                w.Write("MERHABA");

            }

            //using (BinaryWriter w = new BinaryWriter(stream))
            //{
            //    w.Write("MERHABA");
            //}

            //BinaryWriter w = new BinaryWriter(stream);
            //w.Write("MERHABA");

            //byte[] bytes = new byte[client.ReceiveBufferSize];
            //stream.Read(bytes, 0, (int)client.ReceiveBufferSize);

            //string returndata = Encoding.ASCII.GetString(bytes);
            //Console.WriteLine("This is what the host returned to you: " + returndata);

            
                if (stream.CanRead)
                {
                BinaryReader r = new BinaryReader(stream);
                Console.WriteLine(r.ReadString());
            }


            //using (BinaryReader r = new BinaryReader(stream))
            //{
            //    Console.WriteLine(r.ReadString());
            //}

        }
        catch (Exception err)
        {
            Console.WriteLine(err.ToString());
        }
        finally
        {
            client.Close();
            Console.WriteLine("Port closed.");
        }
    }
}