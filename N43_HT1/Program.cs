using N43_HT1;
using N43_HT1.Services;
var userService = new UserService();
var id = userService.Create("Parizoda", "Togayeva");
userService.Create("Maryam", "Sattorova");
userService.Create("Xadicha", "Nazarova");
var employee = new EmployeeService(userService);
var performance = new PerformanceService(userService);
var accountService = new AccountService(employee, performance);
//await accountService.CreateReportAsync(id);
foreach (var item in userService.Get())
{
    await accountService.CreateReportAsync(item.Id);
}
