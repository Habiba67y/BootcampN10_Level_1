using N29.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N29.Interfaces
{
    public interface IHumanResourceManager
    {
        void AddDepartment(Department department);
        List<Department> GetDepartments();
        void EditDepartments(Department department);
        void AddEmployee(Employee employee);
        void RemoveEmployee(int Id);
        void EditEmployee(Employee employee);
        Department FindDepartment(string name);
    }
}
