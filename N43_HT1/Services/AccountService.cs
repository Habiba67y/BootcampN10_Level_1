using Microsoft.VisualBasic;
using N43_HT1.Services.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N43_HT1.Services
{
    public class AccountService
    {
        private readonly EmployeeService employeeService;
        private readonly PerformanceService performanceService;
        public AccountService(EmployeeService employee, PerformanceService performance)
        {
            employeeService = employee;
            performanceService = performance;
        }
        public Task CreateReportAsync(Guid id)
        {
            return employeeService.CreatePerformanceRecordAsync(id).ContinueWith(task => performanceService.ReportPerformanceAsync(task.Result)).Result;
            //performanceService.ReportPerformanceAsync(id).ContinueWith(t => employeeService.CreatePerformanceRecordAsync(t.Result));
        }
    }
}
