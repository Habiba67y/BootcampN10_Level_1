using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static N22_T2.Model.IPriorityQueue;

namespace N22_T2.Model
{
    public class PriorityQueue<TEvent> : IEnumerable<TEvent>, IPriorityQueue<TEvent> where TEvent : ITaskEvent
    {
        private readonly List<TEvent> _events = new();

        public void Enqueue(TEvent eventItem)
        {
            _events.Add(eventItem);
        }

        public TEvent Dequeue()
        {
            var events = _events.OrderBy(e => e.Priority).ToList();
            var t = events[events.Count() - 1];
            _events.Remove(t);
            return t;

        }

        public TEvent Peek()
        {
            var events = _events.OrderBy(e => e.Priority).ToList();
            var t = events[events.Count() - 1];
            return t;
        }

        public IEnumerator<TEvent> GetEnumerator()
        {
            return _events.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _events.GetEnumerator();
        }
    }
}
