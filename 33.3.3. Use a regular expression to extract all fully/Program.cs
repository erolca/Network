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
    }
}
//Downloading http://www.java2s.com
//CatalogJava.htm
//^CTerminate batch job(Y/N)? n