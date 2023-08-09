using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N21
{
    internal class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public User Asignee { get; set; }
        public bool IsCompleted { get; set; }
        public Task(int id, string title, string description, DateTime deadline, User asignee, bool isCompleted)
        {
            Id = id;
            Title = title;
            Description = description;
            Deadline = deadline;
            Asignee = asignee;
            IsCompleted = isCompleted;
        }
        public List<string> Comments  = new List<string>();
    }
}
