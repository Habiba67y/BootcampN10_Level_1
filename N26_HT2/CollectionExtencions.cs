using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N26_HT2
{
    public static class CollectionExtencions
    {
        public static ICollection<Skill> Update(this ICollection<Skill>first, ICollection<Skill>second)
        {
            var FirstList = first.ToList();
            var added = second.ExceptBy(second.Select(s => s.Id), f => f.Id);
            var removed = first.ExceptBy(first.Select(f => f.Id), s => s.Id);
            var updated = first.Select(f => f.Id).Intersect(second.Select(s => s.Id));
            foreach (var item in added) 
                FirstList.Add(item);

            foreach (var item in removed)
                FirstList.Remove(item);

            foreach (var item in updated)
            {
                var f = FirstList.First(i => i.Id == item);
                var s = second.First(i => i.Id == item);
                f.Name = s.Name;
                f.Level = s.Level;
            }
            return FirstList;
        }
    }
}
