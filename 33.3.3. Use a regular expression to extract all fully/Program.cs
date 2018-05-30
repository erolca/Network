using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;


//33.3.3.	Use a regular expression to extract all fully qualified URIs that refer to HTM files

class MainClass
{
    private static void Main()
    {
        string remoteUri = "http://www.java2s.com";

        WebClient client = new WebClient();

        Console.WriteLine("Downloading {0}", remoteUri);

        string str = client.DownloadString(remoteUri);

        MatchCollection matches = Regex.Matches(str, @"http\S+[^-,;:?]\.htm");

        foreach (Match match in matches)
        {
            foreach (Group grp in match.Groups)
            {
                string file = grp.Value.Substring(grp.Value.LastIndexOf('/') + 1);
                Console.WriteLine(file);
            }
        }


        client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

        Stream data = client.OpenRead("http://www.java2s.com");
        StreamReader reader = new StreamReader(data);
        string s = reader.ReadToEnd();
        Console.WriteLine(s);
        data.Close();
        reader.Close();



    }
}
//Downloading http://www.java2s.com
//CatalogJava.htm
//^CTerminate batch job(Y/N)? n