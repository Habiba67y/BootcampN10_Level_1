using N29.Enum;
using N29.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N29.Models
{
    public class Employee: IDepartmentEmployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public Position Position { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public static int _count = 1000;
        public string No { get; set; }
        public Employee(int id, string firstName, string lastName, Position position, decimal salary, int departmentId, string no)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            FullName = $"{firstName} {lastName}";
            Position = position;
            Salary = salary;
            DepartmentId = departmentId;
            No = no;
        }
    }
}
