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

public class BetterDataSender
{
    private void SendData(NetworkStream strm, SerialEmployee emp)
    {
        IFormatter formatter = new SoapFormatter();
        MemoryStream memstrm = new MemoryStream();

        formatter.Serialize(memstrm, emp);
        byte[] data = memstrm.GetBuffer();
        int memsize = (int)memstrm.Length;
        byte[] size = BitConverter.GetBytes(memsize);
        strm.Write(size, 0, 4);
        strm.Write(data, 0, memsize);
        strm.Flush();
        memstrm.Close();
    }

    public BetterDataSender()
    {
        SerialEmployee emp1 = new SerialEmployee();
        SerialEmployee emp2 = new SerialEmployee();

        emp1.EmployeeID = 1;
        emp1.LastName = "Blum";
        emp1.FirstName = "Katie Jane";
        emp1.YearsService = 12;
        emp1.Salary = 35000.50;

        emp2.EmployeeID = 2;
        emp2.LastName = "Blum";
        emp2.FirstName = "Jessica";
        emp2.YearsService = 9;
        emp2.Salary = 23700.30;

        TcpClient client = new TcpClient("127.0.0.1", 9050);
        NetworkStream strm = client.GetStream();

        SendData(strm, emp1);
        SendData(strm, emp2);
        strm.Close();
        client.Close();
    }

    public static void Main()
    {
        BetterDataSender bds = new BetterDataSender();
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