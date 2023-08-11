using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Model
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Developer Asignee { get; set; }
        public bool IsCompleted { get; set; }
        public Task(string title, string description, DateTime deadline)
        {
            Title = title;
            Description = description;
            Deadline = deadline;
            
        }
        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }
    }
}

