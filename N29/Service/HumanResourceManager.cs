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
        private FileService<Department> departments = new FileService<Department>();
        private FileService<Employee> employees = new FileService<Employee>();
        public void AddDepartment(Department department)
        {
            var d = new List<Department>();
            d.Add(department);
            departments.Add(d);
        }

        public void AddEmployee(Employee employee)
        {
            var e = new List<Employee>();
            e.Add(employee);
            employees.Add(e);
        }

        public void EditDepartments(Department department)
        {
            departments.Edit(department);
        }

        public void EditEmployee(Employee employee)
        {
            employees.Edit(employee);
        }

        public Department FindDepartment(int Id)
        {
            return departments.Get(Id);
        }

        public List<Department> GetDepartments()
        {
            return departments.GetValues();
        }

        public void RemoveEmployee(int Id)
        {
            employees.Remove(employees.Get(Id));
        }
    }
}
