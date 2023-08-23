using N29_HT2.Services;
using N29_HT2.Models;

var employeeService = new EmployeeService();
employeeService.employees.Add(new Employee("G'ishmat", "G'ishmatov"));
employeeService.employees.Add(new Employee("Eshmat", "Eshmatov"));
employeeService.employees.Add(new Employee("Toshmat", "Toshmatov"));
await Task.WhenAll(employeeService.HireAsync());