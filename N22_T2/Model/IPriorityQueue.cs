using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N22_T2.Model
{
    internal interface IPriorityQueue
    {
        public interface IPriorityQueue<TEvent> where TEvent : ITaskEvent
        {
            void Enqueue(TEvent eventItem);

            TEvent Dequeue();

            TEvent Peek();
        }
    }
}
