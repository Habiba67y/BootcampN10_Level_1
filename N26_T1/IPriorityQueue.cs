using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N26_T1
{
    public interface IPriorityQueue<TEvent> where TEvent : ITaskEvent
    {
        void Enqueue(TEvent eventItem);

        TEvent Dequeue();

        TEvent Peek();
    }
}
