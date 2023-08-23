using N29.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace N29.Service
{
    public class FileService<T>
    {
        private List<T> _list;
        public static string fileName = $"{nameof(T)}.json";
        public static string folderName = Path.Combine(Directory.GetCurrentDirectory(), "Storage");
        public static string filePath = Path.Combine(folderName, fileName);
        public void Add(List<T> values)
        {
            var fileStream = File.Open(filePath, FileMode.Open);
            if (fileStream.Length == 0)
            {
                JsonSerializer.Serialize(fileStream, values);
            }
            else
            {
                var Data = JsonSerializer.Deserialize<List<T>>(fileStream);
                Data.AddRange(values);
                JsonSerializer.Serialize(fileStream, Data);
            }
        }
    }
}
