using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _26
{
    public class TaskService
    {
        private List<TaskItem> Tasks = new List<TaskItem>();
        public const string path = @"D:\Projects\BootcampN10_Level_1\26\tasks.txt";
        public string json;
        public void AddTask(TaskItem task)
        {
            var tasks = new List<TaskItem>();
            using (StreamReader reader = new StreamReader(TaskService.path))
            {
                var t = File.ReadAllText(path);
                if (!string.IsNullOrEmpty(t))
                    tasks = JsonConvert.DeserializeObject<List<TaskItem>>(reader.ReadToEnd());
                
            }
            tasks.Add(task);
            task.Id = tasks.Count;
            json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(json);
            }
        }
        public bool CompleteTask(int TaskId)
        {
            var task = Tasks.FirstOrDefault(task => task.Id == TaskId);
            if (task != null)
            {
                task.IsCompleted = true;
                return true;
            }
            return false;
        }
        public List<TaskItem> GetTasks(Priority priority)
        {
            return Tasks.Where(task => task.Priority == priority).ToList();
        }
        //public int GetNextId()
        //{
        //    return Tasks.Last().Id + 1;
        //}
    }
}
