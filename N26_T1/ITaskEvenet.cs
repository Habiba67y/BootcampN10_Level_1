using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N26_T1
{
    public interface ITaskEvent
    {
        Guid Id { get; }
        string Name { get; }
        byte Priority { get; }
        void Display()
        {
            Console.WriteLine($"Id: {Id}, Name: {Name}, Priority: {Priority}");
        }

        static bool operator <(ITaskEvent taskA, ITaskEvent taskB)
        {
            return taskA.Priority < taskB.Priority;
        }

        static bool operator >(ITaskEvent taskA, ITaskEvent taskB)
        {
            return taskA.Priority > taskB.Priority;
        }
    }
}
