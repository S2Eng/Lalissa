using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace WCFServicePMDS.Repository
{

    public static class serialize
    {

        public static T Deserialize<T>(this string toDeserialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringReader textReader = new StringReader(toDeserialize))
            {
                return (T)xmlSerializer.Deserialize(textReader);
            }
        }

        public static string Serialize<T>(this T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }


        public static byte[] BinarySerialize<T>(T obj)
        {
            MemoryStream memorystream = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(memorystream, obj);
            byte[] byt = memorystream.ToArray();
            return byt;
        }
        public static object BinaryDeserialize(byte[] byt)
        {
            MemoryStream memorystreamd = new MemoryStream(byt);
            BinaryFormatter bfd = new BinaryFormatter();
            object obj = bfd.Deserialize(memorystreamd);
            return obj;
        }

    }

}
