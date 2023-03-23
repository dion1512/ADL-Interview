using ADL.Data.Entities;
using ADL.Web.Models;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
using System.Xml;

namespace ADL.Web.Utils
{
    public class Utils
    {
        public static string createJSONFile(Callout callout)
        {
            string projectDirectory = Environment.CurrentDirectory;
            string fileName = "Engineer Callout Record - " + (callout.DateBookedStart).ToString(@"ddMMyyyyHHmmss");

            using FileStream createStream = System.IO.File.Create($@"{projectDirectory}\wwwroot\Downloads\JSON\{fileName}.json");
            JsonSerializer.SerializeAsync(createStream, callout);
            return $"{fileName}.json";
        }
        public static string createXMLFile(Callout callout)
        {
            string projectDirectory = Environment.CurrentDirectory;
            string fileName = "Engineer Callout Record - " + (callout.DateBookedStart).ToString(@"ddMMyyyyHHmmss");

            var xmlSerializer = new XmlSerializer(callout.GetType());
            var xmlWriterSettings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  ",
                NewLineChars = "\r\n",
                NewLineHandling = NewLineHandling.Replace,
                Encoding = Encoding.UTF8
            };
            var xmlWriter = XmlWriter.Create($@"{projectDirectory}\wwwroot\Downloads\XML\{fileName}.xml", xmlWriterSettings);
            xmlSerializer.Serialize(xmlWriter, callout);
            return $"{fileName}.xml";
        }
        public class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }
    }
}
