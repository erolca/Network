//http://simpledbbrowser.codeplex.com/
//License:  Microsoft Public License (Ms-PL)  
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AWS.Framework.WPF.Utility
{
    public sealed class Helpers
    {
        public static T DeepCopy<T>(object toClone)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, toClone);
                ms.Position = 0;
                return (T)bf.Deserialize(ms);
            }
        }
    }

    class MyClass
    {
        public static void Main()
        {


        }
    }
}