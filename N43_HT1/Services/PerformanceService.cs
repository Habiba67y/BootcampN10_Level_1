using N43_HT1.Services.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N43_HT1.Services
{//PerformanceService

    //- ReportPerformanceAsync ( id ) -berilgan userni fullname bilan yaratilgan faylni ochib, ichiga "All good :)" deb yozsin

    public class PerformanceService
    {
        public readonly IUserService _userService;
        public PerformanceService(UserService userService)
        {
            _userService = userService;
        }
        public Task<Guid> ReportPerformanceAsync(Guid id)
        {
            var mutex = new Mutex(false, "Mutex");
            var user = _userService.Get().FirstOrDefault(x => x.Id == id);
            var filePath = $@"D:\Projects\BootcampN10_Level_1\N43_HT1\bin\Debug\net7.0\{user.FirstName.ToLower()}{user.LastName.ToLower()}.txt";
            return Task.Run(async () =>
            {
                mutex.WaitOne();
                var fileStream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite);
                Console.WriteLine($"{user.FirstName} {user.LastName}.txt file opened");
                Console.WriteLine("Writing ...");
                fileStream.Write(Encoding.UTF8.GetBytes("All good :)"));
                fileStream.Flush();
                fileStream.Close();
                Console.WriteLine($"{user.FirstName} {user.LastName}.txt file closed");
                mutex.ReleaseMutex();
                return user.Id;
            });
        }
    }
}
