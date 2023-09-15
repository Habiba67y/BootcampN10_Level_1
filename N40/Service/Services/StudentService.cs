using N40.Data.Condfig;
using N40.Domain.Entities;
using N40.Service.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace N40.Service.Services
{
    public class StudentService : IStudentService
    {
        public List<Student> students;
        public StudentService()
        {
            string source = null;
            if (File.Exists(Constants.STUDENT_DB))
            {
                source = File.ReadAllText(Constants.STUDENT_DB);
            }
            if (source != null)
            {
                students = JsonConvert.DeserializeObject<List<Student>>(source);
            }
            students = new List<Student>();
        }
        public Student Create(Student student)
        {
            if (student != null) throw new ArgumentNullException(nameof(student));
            students.Add(student);
            student.CreatedAt = DateTime.Now;
            JsonConvert.SerializeObject(students);
            return student;
        }

        public bool Delete(int Id)
        {
            try 
            { 
                var student = GetById(Id);
                students.Remove(student);
                JsonConvert.SerializeObject(students);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Student> GetAll()
        {
            return students;
        }

        public Student GetById(int Id)
        {
            var student = students.FirstOrDefault(x => x.Id == Id);
            return student != null ? student : throw new ArgumentNullException(nameof(student));
        }

        public Student Update(Student student)
        {
            var updatedStudent = GetById(student.Id);
            updatedStudent.FirstName = student.FirstName;
            updatedStudent.LastName = student.LastName;
            updatedStudent.ProjectPath = student.ProjectPath;
            updatedStudent.CrmId = student.CrmId;
            updatedStudent.UpdatedAt = DateTime.Now;
            JsonConvert.SerializeObject(students);
            return updatedStudent;
        }
    }
}
