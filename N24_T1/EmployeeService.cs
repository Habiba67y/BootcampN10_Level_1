using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N24_T1
{
    public class EmployeeService
    {
        public List<Employee> employees = new List<Employee>();
        public List<Employee> GetBySalary(int pageSize, int pageToken)
        {
            var emp = employees.OrderByDescending(employee => employee.Salary).ToList();
            return emp.Skip((pageToken - 1) * pageSize).Take(pageSize).ToList();     
        }
    }
}
