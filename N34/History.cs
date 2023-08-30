using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace N34
{
    public class History
    {
        public List<Person> people = new List<Person>();
        public List<PersonHistory>histories = new List<PersonHistory>();
        public void Add(Person person)
        {
            people.Add(person);
            histories.Add(new PersonHistory(person.Id, $"{person.FirstName} qo'shildi"));
        }
        public void Remove(Person person)
        {
            //people.Remove(person);
            histories.Add(new PersonHistory(person.Id, $"{person.FirstName} olib tashlandi"));
        }
        public void Update(Person person)
        {
            var p = people.FirstOrDefault(x => x.Id == person.Id);
            if (p != null)
            {
                histories.Add(new PersonHistory(person.Id,$"{p.FirstName} {person.FirstName} ga yangilandi"));
                p.FirstName = person.FirstName;
                p.LastName = person.LastName;
            }
        }
        public void Display()
        {
            Console.WriteLine(JsonSerializer.Serialize(people.GroupJoin(histories, p => p.Id, h => h.PersonId, (people, histories) => new { Person = people, history = histories})));
        }
    }
}
