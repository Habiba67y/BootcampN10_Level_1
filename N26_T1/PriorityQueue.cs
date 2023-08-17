using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N26_T1
{
    public class PriorityQueue<TItem> : IEnumerable<TItem>, IPriorityQueue<TItem> where TItem : ITaskEvent
    {
        private readonly List<TItem> _events = new();

        public void Enqueue(TItem eventItem)
        {
            _events.Add(eventItem);
        }

        public TItem Dequeue()
        {
            
            // Eski usul
            // if (_events.Count == 0)
            //     throw new InvalidOperationException("Queue is empty");
            //
            // var maxPriorityEvent = _events[0];
            // foreach(var item in _events)
            // {
            //     if (item.Priority > maxPriorityEvent.Priority)
            //         maxPriorityEvent = item;
            // }
            //
            // _events.Remove(maxPriorityEvent);
            // return maxPriorityEvent;
            for (int i = 0; i < _events.Count - 1; i++)
            {
                for (int j = i + 1; j < _events.Count; j++)
                {
                    if (_events[i] > _events[j])
                    {
                        var temp = _events[i];
                        _events[i] = _events[j];
                        _events[j] = temp;
                    }
                }
            }
            var item = _events.Count > 0
                ? _events.MaxBy(item => item.Priority)
                : throw new InvalidOperationException("Queue is empty");

            _events.Remove(item);
            return item;
        }

        public TItem Peek()
        {
            return _events.Count > 0
                ? _events.MaxBy(item => item.Priority)
                : throw new InvalidOperationException("Queue is empty");

            // Eski usul

            // if (_events.Count == 0)
            //     throw new InvalidOperationException("Queue is empty");
            //
            // var maxPriorityEvent = _events[0];
            // foreach(var item in _events)
            // {
            //     if (item.Priority > maxPriorityEvent.Priority)
            //         maxPriorityEvent = item;
            // }
            //
            // return maxPriorityEvent;
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return _events.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _events.GetEnumerator();
        }
    }
}
