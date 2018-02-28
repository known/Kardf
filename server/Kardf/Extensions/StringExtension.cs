using System.Text;
using System.Xml;

namespace Kardf.Extensions
{
    public static class StringExtension
    {
        public static int ByteLength(this string value)
        {
            return Encoding.Default.GetBytes(value).Length;
        }

        public static string ByteSubstring(this string value, int startIndex)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            var length = value.ByteLength();
            return value.ByteSubstring(startIndex, length);
        }

        public static string ByteSubstring(this string value, int startIndex, int length)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            var actualLength = value.ByteLength();
            var count = length > (actualLength - startIndex)
                      ? actualLength - startIndex
                      : length;
            var encoding = Encoding.GetEncoding("GB2312");
            var bytes = encoding.GetBytes(value);
            return encoding.GetString(bytes, startIndex, count);
        }

        public static string FormatXml(this string xml)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            var sb = new StringBuilder();
            var settings = new XmlWriterSettings { Indent = true, Encoding = Encoding.UTF8 };
            using (var xtw = XmlWriter.Create(sb, settings))
            {
                doc.WriteTo(xtw);
            }
            return sb.ToString();
        }
    }
}
