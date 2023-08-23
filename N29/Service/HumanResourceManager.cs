using N29.Enum;
using N29.Interfaces;
using N29.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace N29.Service
{
    public class HumanResourceManager : IHumanResourceManager
    {
        private List<Department> departments = new List<Department>();
        private List<Employee> employees = new List<Employee>();
        public void AddDepartment(Department department)
        {
            departments.Add(department);
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void EditDepartments(Department department)
        {
            var depart = departments.FirstOrDefault(d => d.Id == department.Id);
            if (depart != null)
            {
                depart.Name = department.Name;
                depart.WorkerLimit = department.WorkerLimit;
                depart.SalaryLimit = department.SalaryLimit;
                depart.Employees = department.Employees;
            }
        }

        public void EditEmployee(Employee employee)
        {
            var empl = employees.FirstOrDefault(e => e.Id == employee.Id);
            if (empl != null)
            {
                empl.FirstName = employee.FirstName;
                empl.LastName = employee.LastName;
                empl.FullName = employee.FullName;
                empl.Position = employee.Position;
                empl.Salary = employee.Salary;
                empl.DepartmentId = employee.DepartmentId;
                empl.No = employee.No;
            }
        }

        public Department FindDepartment(string name)
        {
            return departments.FirstOrDefault(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public List<Department> GetDepartments()
        {
            return departments;
        }

        public void RemoveEmployee(int Id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == Id);
            if (employee != null)
            {
                employees.Remove(employee);    
            }
        }
    }
}
