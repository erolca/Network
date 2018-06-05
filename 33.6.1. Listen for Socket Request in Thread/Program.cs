using System;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

public class MainClass {

    const int echoPort = 9050;
    static void ListenForRequests()
    {
        int CONNECT_QUEUE_LENGTH = 4;
        
        Socket listenSock = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
        listenSock.Bind( new IPEndPoint(IPAddress.Any, echoPort) );
        listenSock.Listen( CONNECT_QUEUE_LENGTH );

        while( true ) {
            using( Socket newConnection = listenSock.Accept() ) {
                // Send the data.
                byte[] msg = Encoding.UTF8.GetBytes( "Hello World!" );
                newConnection.Send( msg, SocketFlags.None );
            }
        }
    }

    static void Main() {
        // Start the listening thread.
        Thread listener = new Thread(new ThreadStart(ListenForRequests) );
        listener.IsBackground = true;
        listener.Start();

        Console.WriteLine( "Press <enter> to quit" );
        Console.ReadLine();
    }
}