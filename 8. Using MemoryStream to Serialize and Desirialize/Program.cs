using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace PDM.Data
{
    public class SerializerUtil
    {
        private static readonly XmlSerializer _serializer = new XmlSerializer(typeof(List<object>));

        public static string SerializeList(List<object> list)
        {
            using (var stream = new MemoryStream())
            {
                _serializer.Serialize(stream, list);
                stream.Position = 0;
                return Encoding.UTF8.GetString(stream.GetBuffer());
            }
        }

        public static List<object> DesirializeList(string data)
        {
            if (string.IsNullOrEmpty(data))
                return null;

            using (var stream = new MemoryStream())
            {
                var bytes = Encoding.UTF8.GetBytes(data);
                stream.Write(bytes, 0, bytes.Length);
                stream.Position = 0;
                return (List<object>)_serializer.Deserialize(stream);
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