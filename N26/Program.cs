using _26;
using System.Text.Json;
using System.Xml;
using Newtonsoft.Json;

var taskService = new TaskService();
var task1 = new TaskItem( "1-task", Priority.Low, DateTime.Now.AddDays(2), false);
var task2 = new TaskItem( "2-task", Priority.Hight, DateTime.Now.AddDays(1), false);
var task3 = new TaskItem("3-task", Priority.Medium, DateTime.Now.AddHours(15), false);
var task4 = new TaskItem("4-task", Priority.Hight, DateTime.Now.AddDays(3), false);
taskService.AddTask(task3); 
taskService.AddTask(task1);
taskService.AddTask(task2);
taskService.AddTask(task4);

using (StreamReader reader = new StreamReader(TaskService.path))
{
    var tasks = JsonConvert.DeserializeObject<List<TaskItem>>(reader.ReadToEnd());
    tasks.ForEach(Console.WriteLine);
}