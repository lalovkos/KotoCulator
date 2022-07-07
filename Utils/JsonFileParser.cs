using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotoCulator.Utils
{
    internal static class JsonFileParser
    {
        public static T? ReadJsonFromFile<T>(string filePath)
        {
            FileStream stream = File.OpenRead(filePath);
            using (StreamReader reader = new StreamReader(stream))
            {
                return ReadJsonFromString<T>(reader.ReadToEnd());
            }
        }

        public static T? ReadJsonFromString<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static void WriteJsonToFile(object obj, string filePath)
        {
            FileStream stream = File.OpenWrite(filePath);
            using (StreamWriter reader = new StreamWriter(stream))
            {
                reader.Write(WriteJsonToString(obj));
            }
        }

        public static string WriteJsonToString(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}