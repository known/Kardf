﻿using Newtonsoft.Json;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Kardf.Extensions
{
    public static class SerializeExtension
    {
        public static string ToJson(this object value)
        {
            if (value == null)
                return string.Empty;

            return JsonConvert.SerializeObject(value);
        }

        public static T FromJson<T>(this string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return default(T);

            var settings = new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-dd HH:mm:ss"
            };
            return JsonConvert.DeserializeObject<T>(json, settings);
        }

        public static string ToXml(this object value)
        {
            if (value == null)
                return string.Empty;

            if (value is DataTable)
            {
                var sb = new StringBuilder();
                var writer = XmlWriter.Create(sb);
                var serializer = new XmlSerializer(typeof(DataTable));
                serializer.Serialize(writer, value);
                writer.Close();
                return sb.ToString();
            }

            var settings = new XmlWriterSettings { Indent = true, Encoding = Encoding.UTF8 };
            using (var stream = new MemoryStream())
            {
                using (var writer = XmlWriter.Create(stream, settings))
                {
                    var namespaces = new XmlSerializerNamespaces();
                    namespaces.Add("", "");
                    var serializer = new XmlSerializer(value.GetType());
                    serializer.Serialize(writer, value, namespaces);
                }
                var xml = Encoding.UTF8.GetString(stream.ToArray());
                //去除第一个字符问号
                return xml.Substring(1);
            }
        }

        public static T FromXml<T>(this string xml) where T : class
        {
            if (string.IsNullOrEmpty(xml))
                return default(T);

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(reader);
            }
        }

        public static byte[] ToBytes(this object value)
        {
            if (value == null)
                return null;

            byte[] bytes = null;
            using (var ms = new MemoryStream())
            {
                var bf = new BinaryFormatter();
                bf.Serialize(ms, value);
                bytes = ms.ToArray();
                ms.Flush();
                ms.Close();
            }
            return bytes;
        }

        public static object FromBytes(this byte[] buffer)
        {
            if (buffer == null)
                return null;

            using (var ms = new MemoryStream(buffer))
            {
                var bf = new BinaryFormatter();
                return bf.Deserialize(ms);
            }
        }
    }
}
