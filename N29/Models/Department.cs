using N29.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N29.Models
{
    public class Department: IDepartmentEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WorkerLimit { get; set; }
        public int SalaryLimit { get; set; }
        public List<Employee> Employees { get; set; }
        public Department(int id, string name, int workerLimit, int salaryLimit)
        {
            Id = id;
            Name = name;
            WorkerLimit = workerLimit;
            SalaryLimit = salaryLimit;
            Employees = new List<Employee>();
        }
        public decimal CalcSalaryAvr()
        {
            return Employees.Average(e => e.Salary);
        }
    }
}
