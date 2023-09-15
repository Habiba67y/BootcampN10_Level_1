using N40.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N40.Service.Interfaces
{
    public interface IStudentService
    {
        Student Create(Student student);
        Student Update(Student student);
        bool Delete(int Id);
        Student GetById(int Id);
        IEnumerable<Student> GetAll();
    }
}
