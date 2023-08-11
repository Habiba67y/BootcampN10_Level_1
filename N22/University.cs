using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N22
{
    public class University<TStudent, TId, TGrade> where TStudent : Student<TId, TGrade> 
    {
        List<TStudent> Students { get; set; }
        List<Course> Courses { get; set; }
        public University()
        {
            Students = new List<TStudent>();
            Courses = new List<Course>();
        }
        public void EnrollStudent(TStudent student, Course course)
        {
            Students.Add(student);
            Courses.Add(course);
        }
        public override string ToString()
        {
            var str = "";
            for(int i=0; i<Students.Count; i++)
            {
                str += Students[i].ToString();
                str += $"\nCourse: {Courses[i].Title}\n\n";
            }
            return str;
        }
    }
}
