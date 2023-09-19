using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N41_HT1
{
    public class ThreadSafeQueue<T> : IEnumerable<T>
    {
        private Queue<T> Queue;
        private readonly object _lock = new();
        public ThreadSafeQueue()
        {
            Queue = new ();
        }

        public ValueTask Enqueue(T item)
        {
            lock (_lock)
            {
                Queue.Enqueue(item);

            }
            return new ValueTask(Task.CompletedTask);
        }
        public ValueTask<T> Dequeue()
        {
            T item;
            lock(_lock) 
            {
                item = Queue.Dequeue();
            }
            Console.WriteLine(item);
            return ValueTask.FromResult(item);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return Queue.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
