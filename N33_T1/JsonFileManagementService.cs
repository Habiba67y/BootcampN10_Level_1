using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace N33_T1
{
    public sealed class JsonFileManagementService : FileManagementServiceBase
    {
        public async override Task<string> ReadAsync(string filePath)
        {
            if (!filePath.EndsWith(".json"))
            {
                throw new InvalidOperationException("Bu file json emas!");
            }
            return await File.ReadAllTextAsync(filePath);
        }

        public async override Task WriteAsync(string filePath, string data)
        {
            if(!filePath.EndsWith(".json"))
            {
                throw new InvalidOperationException("Bu file json emas!");
            }
            await File.WriteAllTextAsync(filePath, data);
        }
        public Task<T> ReadAsync<T>(string filePath)
        {
            if (!filePath.EndsWith(".json"))
            {
                throw new InvalidOperationException("Bu file json emas!");
            }
            var fileStream = File.Open(filePath, FileMode.Open);
            return Task.FromResult(JsonSerializer.Deserialize<T>(fileStream));
        }
    }
}
