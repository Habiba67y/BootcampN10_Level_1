using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N21
{
    internal class TaskManagerSystem
    {
        private List<User> users = new List<User>();
        private List<Project> projects = new List<Project>();
        public void CreateProject(int Id, string Title, string Description, User Manager)
        {
            var project = new Project(Id, Title, Description, Manager);
        }
        public void CreateTask(Project project, Task task)
        {
            project.AddTask(task);    
        }
        public void ShowProjects()
        {
            Console.WriteLine("Projects:");
            foreach (var project in projects)
            {
                Console.WriteLine($"\tId: {project.Id} - Project title: {project.Title}");
            }
        }
        public void CreateNotification(User Recipient, string Message)
        {
            var notification = new Notification(Recipient, Message);
        }
    }
}
