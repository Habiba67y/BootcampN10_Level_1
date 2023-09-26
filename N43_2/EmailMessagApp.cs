using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N43_2
{
    public static class EmailMessageApp
    {
        public static Task WriteMessageAsync()
        {
            var filePath = @"D:\Projects\file.txt";
            var mutex = new Mutex(false, "Mutex");
            return Task.Run(() =>
            {
                mutex.WaitOne();
                var guid = Guid.NewGuid();

                var fileStream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite);  


                Console.WriteLine($"App {guid} opened the file");
                Console.WriteLine("reading template");
                
                var buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, buffer.Length);
                var message = Encoding.UTF8.GetString(buffer).Replace("{{UserName}}", "Xullas");
                
                Console.WriteLine("Writing message");
                Console.WriteLine(message);

                fileStream.Seek(0, SeekOrigin.Begin);
                fileStream.Write(Encoding.UTF8.GetBytes(message));
                
                fileStream.Flush();
                fileStream.Close();
                
                Console.WriteLine($"App {guid} closed the file");
                mutex.ReleaseMutex();
            });
        }
    }
}
