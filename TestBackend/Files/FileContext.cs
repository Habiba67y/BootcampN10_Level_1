using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TestBackend.Models;

namespace TestBackend.Files
{
    public class FileContext : IFileContext
    {
        private string _filePath = @"D:\Projects\BootcampN10_Level_1\TestBackend\Files\file.json";
        private List<User> users;
        public FileContext()
        {
            if (File.ReadAllText(_filePath).Length == 0)
            {
                users = new List<User>(); 
            }
            else
            {
                users = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(_filePath));
            }
        }
        public User AddUser(User user)
        {
            users.Add(user);
            var json = JsonSerializer.Serialize(users);
            File.WriteAllText(_filePath, json);
            return user;
        }

        public User Delete(User user)
        {
            users.Remove(user);
            var json = JsonSerializer.Serialize(users);
            File.WriteAllText(_filePath, json);
            return user;
        }

        public User? GetById(Guid Id)
        {
            return users.FirstOrDefault(x => x.Id == Id);
        }

        public List<User> GetUsers()
        {
            return users;
        }

        public User Update(User user)
        {
            var u = users.FirstOrDefault(x => x.Id == user.Id);
            if (u != null)
            {
                u.Name = user.Name;
                u.Age = user.Age;
                var json = JsonSerializer.Serialize(users);
                File.WriteAllText(_filePath, json);
                return user;
            }
            throw new NotImplementedException("Bunday user mavjud emas");
        }
    }
}
