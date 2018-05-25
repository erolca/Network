/*
C# Network Programming 
by Richard Blum

Publisher: Sybex 
ISBN: 0782141765
*/

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

public class BetterDataRcvr
{
    private SerialEmployee RecvData(NetworkStream strm)
    {
        MemoryStream memstrm = new MemoryStream();
        byte[] data = new byte[4];
        int recv = strm.Read(data, 0, 4);
        int size = BitConverter.ToInt32(data, 0);
        int offset = 0;
        while (size > 0)
        {
            data = new byte[1024];
            recv = strm.Read(data, 0, size);
            memstrm.Write(data, offset, recv);
            offset += recv;
            size -= recv;
        }
        IFormatter formatter = new SoapFormatter();
        memstrm.Position = 0;
        SerialEmployee emp = (SerialEmployee)formatter.Deserialize(memstrm);
        memstrm.Close();
        return emp;
    }

    public BetterDataRcvr()
    {
        TcpListener server = new TcpListener(9050);
        server.Start();
        TcpClient client = server.AcceptTcpClient();
        NetworkStream strm = client.GetStream();

        SerialEmployee emp1 = RecvData(strm);
        Console.WriteLine("emp1.EmployeeID = {0}", emp1.EmployeeID);
        Console.WriteLine("emp1.LastName = {0}", emp1.LastName);
        Console.WriteLine("emp1.FirstName = {0}", emp1.FirstName);
        Console.WriteLine("emp1.YearsService = {0}", emp1.YearsService);
        Console.WriteLine("emp1.Salary = {0}\n", emp1.Salary);

        SerialEmployee emp2 = RecvData(strm);
        Console.WriteLine("emp2.EmployeeID = {0}", emp2.EmployeeID);
        Console.WriteLine("emp2.LastName = {0}", emp2.LastName);
        Console.WriteLine("emp2.FirstName = {0}", emp2.FirstName);
        Console.WriteLine("emp2.YearsService = {0}", emp2.YearsService);
        Console.WriteLine("emp2.Salary = {0}", emp2.Salary);
        strm.Close();
        server.Stop();
    }

    public static void Main()
    {
        BetterDataRcvr bdr = new BetterDataRcvr();
    }
}



[Serializable]
public class SerialEmployee
{
    public int EmployeeID;
    public string LastName;
    public string FirstName;
    public int YearsService;
    public double Salary;

    public SerialEmployee()
    {
        EmployeeID = 0;
        LastName = null;
        FirstName = null;
        YearsService = 0;
        Salary = 0.0;
    }
}
