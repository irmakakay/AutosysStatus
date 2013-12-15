using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Runtime.Serialization;

namespace AutosysStatusTranslator
{
    public class TreeSerializer
    {
        public static string SerializeToJson<T>(T graph)
        {
            return Serialize(graph, new DataContractJsonSerializer(typeof(T)));
        }

        public static string SerializeToXml<T>(T graph)
        {
            return Serialize(graph, new DataContractSerializer(typeof(T)));
        }

        private static string Serialize<T>(T graph, XmlObjectSerializer serializer)
        {
            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, graph);

                using (var reader = new StreamReader(stream))
                {
                    stream.Position = 0;

                    return reader.ReadToEnd();
                }
            }
        }
    }
}
