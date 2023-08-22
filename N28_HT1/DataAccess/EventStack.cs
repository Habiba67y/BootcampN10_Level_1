using N28_HT1.Models.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace N28_HT1.DataAccess
{
    public class EventStack<T> : IEnumerable<T> where T : IEvent
    {
        private readonly List<T> events = new List<T>();
        public void Push(T eventItem)
        {
            var eventA = events.FirstOrDefault(x => x.Id == eventItem.Id);
            if (eventA != null)
            {
                if (!EqualityComparer<T>.Default.Equals(eventA, events.MaxBy(x => x.Date)))
                {
                    throw new Exception("...");
                }
            }
            events.Add(eventItem);
        }
        public T Peek() => events.Last();

        public T Pop()
        {
            var e = events.Last();
            events.Remove(e);
            return e;
        }
        public int Length() => events.Count();
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
