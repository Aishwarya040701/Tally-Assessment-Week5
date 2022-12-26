using Microsoft.AspNetCore.Mvc;
using StudentEF.Models;

namespace StudentEF.Interface
{
    public interface IStudent
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentById(int id);
        Student PostStudent(Student student);
        Student PutStudent(Student student);
        bool DeleteStudent(int id);

        bool checkId(int id);
       


        void Save();
    }
}
