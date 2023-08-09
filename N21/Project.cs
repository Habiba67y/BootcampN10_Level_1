using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N21
{
    internal class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public User Manager { get; set; }
        public List<Task> Tasks = new List<Task>();
        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }
        public Project(int id, string title, string description, User manager)
        {
            Id = id;
            Title = title;
            Description = description;
            Manager = manager;
        }
    }
}
