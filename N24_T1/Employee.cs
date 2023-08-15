using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N24_T1
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Salary { get; set; }
        public int Kpi { get; set; }
        //public Employee(string firstName, string lastName, float salary, int kpi) 
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //    Salary = salary;
        //    KPI = kpi;
        //}
        public override string ToString()
        {
            return $"First name: {FirstName}\nLast name: {LastName}\nSalary: {Salary}\nKPI: {Kpi}\n";
        }
    }
}
