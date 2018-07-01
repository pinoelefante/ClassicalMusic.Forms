using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ClassicalMusic.Services
{
    public class AssemblyFileReader
    {
        public static T ReadLocalJson<T>(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"ClassicalMusic.{filename.Replace(Path.PathSeparator, '.')}");
            string text = string.Empty;
            using (var reader = new StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<T>(text);
        }
        public static string ReadLocalJson(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"ClassicalMusic.{filename.Replace(Path.PathSeparator, '.')}");
            string text = string.Empty;
            using (var reader = new StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
            return text;
        }
        public static Stream GetReadStream(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"ClassicalMusic.{filename.Replace(Path.PathSeparator, '.')}");
            return stream;
        }
        public static byte[] GetByteContent(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            byte[] content = null;
            using (Stream stream = assembly.GetManifestResourceStream($"ClassicalMusic.{filename.Replace(Path.PathSeparator, '.')}"))
            {
                content = new byte[stream.Length];
                stream.Read(content, 0, content.Length);
            }
            return content;
        }
        public static MemoryStream GetMemoryStream(string filename)
        {
            var content = GetByteContent(filename);
            return new MemoryStream(content);
        }
    }
}
