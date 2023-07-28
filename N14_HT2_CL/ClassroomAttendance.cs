using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N14_HT2_CL
{
    public class ClassroomAttendance
    {
        protected Dictionary<string, string> students = new Dictionary<string, string>();
        public virtual void Display()
        {
            foreach (var student in students)
            {
                Console.WriteLine($"Fullname: {student.Key}\nIs present: {student.Value}");
            }
        }
        public void Mark(string fullname, bool isPresent)
        {
            if (students.ContainsKey(fullname))
            {
                if (isPresent)
                {
                    students[fullname] = "present";
                }
                else
                {
                    students[fullname] = "ansent";
                }
            }
            else
            {
                if (isPresent)
                {
                    students.Add(fullname, "present");
                }
                else
                {
                    students.Add(fullname, "absent");
                }
            }
        }
        internal protected float GetStatus()
        {
            var count = 0;
            foreach (var student in students)
            {
                if (student.Value.Contains("present", StringComparison.OrdinalIgnoreCase))
                {
                    count++;
                }
            }
            return (100F/students.Count())*count;
        }
    }
    public class UltimateClassroomAttendance : ClassroomAttendance
    {
        public UltimateClassroomAttendance()
        {
            students = new Dictionary<string, string>();
        }
        public void Mark(string fullname, bool isPresent, string cause)
        {
            if (students.ContainsKey(fullname))
            {
                if (isPresent)
                {
                    students[fullname] = "present - " + cause;
                }
                else
                {
                    students[fullname] = "ansent - " + cause;
                }
            }
            else
            {
                if (isPresent)
                {
                    students.Add(fullname, "present - " + cause);
                }
                else
                {
                    students.Add(fullname, "absent - "+cause);
                }
            }
        }
        public override void Display()
        {
            Console.WriteLine("Students:");
            base.Display();
            Console.WriteLine("Status:");
            Console.WriteLine(base.GetStatus());
        }
    }
}
