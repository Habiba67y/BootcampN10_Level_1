using N43_HT1.Services.Intefaces;
using N43_HT1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Channels;

namespace N43_HT1
{
    public class EmployeeService
    {
        private readonly IUserService _userService;
        public EmployeeService(UserService userService)
        {
            _userService = userService;
        }
        public Task<Guid> CreatePerformanceRecordAsync(Guid id)
        {
           
            var mutex = new Mutex(false, "Mutex");
            var user = _userService.Get().FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                user = _userService.Get().FirstOrDefault();
            }
            return Task.Run(async () =>
            {
                mutex.WaitOne();
                
                var fileStream = File.Create($"{user.FirstName.ToLower()}{user.LastName.ToLower()}.txt");
                Console.WriteLine($"Created {user.FirstName.ToLower()} {user.LastName.ToLower()}.txt file");
                fileStream.Flush();
                fileStream.Close();
                mutex.ReleaseMutex();
                return user.Id;
            });
        }
    }
}
