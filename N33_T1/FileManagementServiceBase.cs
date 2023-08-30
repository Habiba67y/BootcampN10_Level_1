using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N33_T1
{
    public abstract class FileManagementServiceBase
    {
        public abstract Task<string> ReadAsync(string filePath);
        public abstract Task WriteAsync(string filePath, string data);
    }
}
