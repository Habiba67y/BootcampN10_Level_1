
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N43
{//EmailTemplateApp - faylni ochadi unga template yozadi va 10 sekund kutib turadi
    public static class EmailTemplateApp
    {
        public static Task WriteTemplateAsync()
        {
            var filePath = @"D:\Projects\file.txt";
            var mutex = new Mutex(false, "Mutex");
            return Task.Run(() =>
            {
                mutex.WaitOne();
                var guid = Guid.NewGuid();

                var fileStream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite);
                Console.WriteLine($"App {guid} opened the file");
                Console.WriteLine("Writing template");
                
                fileStream.Write(Encoding.UTF8.GetBytes("Assalomu alaykum, Congratulations! {{UserName}}, you registered succesfully!"));
                Thread.Sleep(10000);
                
                
                fileStream.Flush();
                fileStream.Close();
                
                Console.WriteLine($"App {guid} closed the file");
                mutex.ReleaseMutex();
            });
        }
    }
}
