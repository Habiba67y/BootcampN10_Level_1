using N29.Interfaces;
using N29.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace N29.Service
{
    public class FileService<T> where T : IDepartmentEmployee
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
        public void Edit(T value)
        {
            var fileStream = File.Open(filePath, FileMode.Open);
            var t = Get(value.Id);
            if (t != null)
            {
                if (t is Employee employee1 && value is Employee employee2)
                {
                    employee1.FirstName = employee2.FirstName;
                    employee1.LastName = employee2.LastName;
                    employee1.FullName = employee2.FullName;
                    employee1.Position = employee2.Position;
                    employee1.Salary = employee2.Salary;
                    employee1.DepartmentId = employee2.DepartmentId;
                    employee1.No = employee2.No;
                }
                if (t is Department department1 && t is Department department2)
                {
                    department1.Name = department2.Name;
                    department1.WorkerLimit = department2.WorkerLimit;
                    department1.SalaryLimit = department2.SalaryLimit;
                    department1.Employees = department2.Employees;
                }
                JsonSerializer.Serialize(fileStream, GetValues());
            }
        }
        public T Get(int Id)
        {
            return GetValues().FirstOrDefault(d => d.Id == Id);
        }
        public void Remove(T value)
        {
            var fileStream = File.Open(filePath, FileMode.Open);
            GetValues().Remove(value);
            JsonSerializer.Serialize(fileStream, GetValues());
        }
        public List<T> GetValues()
        {
            var fileStream = File.Open(filePath, FileMode.Open);
            if (fileStream.Length == 0)
            {
                return new List<T>();
            }
            else
            {
                var Data = JsonSerializer.Deserialize<List<T>>(fileStream);
                return Data;
            }
        }
    }
}
