using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N22
{
    public class Student<TId, TGrade>
    {
        public TId Id { get; set;}
        public string Name { get; set;}
        public TGrade Grade { get; set;}
        public Student(TId id, string name, TGrade grade)
        {
            Id = id;
            Name = name;
            Grade = grade;
        }
        public override string ToString() 
        {
            return $"Id: {Id}\nName: {Name}\nGrade: {Grade}";
        }
    }
}
