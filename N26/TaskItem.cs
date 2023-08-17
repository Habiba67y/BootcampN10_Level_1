using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public DateTime DeadLine { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public TaskItem(string description, Priority priority, DateTime deadLine, bool isCompleted) 
        {
            //Id = id;
            Description = description;
            Priority = priority;
            DeadLine = deadLine;
            IsCompleted = isCompleted;
            CreatedDate = DateTime.Now;
        }
        public override string ToString()
        {
            return $"\nId: {Id}\nDescription: {Description}\nPriority: {Priority}\nIs completed: {IsCompleted}";
        }
    }
}
