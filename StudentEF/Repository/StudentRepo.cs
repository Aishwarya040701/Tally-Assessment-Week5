using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using StudentEF.Interface;
using StudentEF.Models;

namespace StudentEF.Repository
{
    public class StudentRepo:IStudent
    {

        private readonly DataContext _context;
         

        public StudentRepo(DataContext context)
        {
            _context = context;
            

        }


        public IEnumerable<Student> GetStudents()
        {
            IEnumerable<Student> student =  _context.Students
                .Include(u=>u.Subjects)
                .ToList();


            return student;

        }


        public Student GetStudentById(int id)
        {
            var student = _context.Students
                .Include(u => u.Subjects)
                .FirstOrDefault(u => u.StudentId == id);
                
                
           
            return student;




        }





        public Student PostStudent(Student student)
        {
            

            _context.Students.Add(student);

                Save();
                return student;
           



        }

        public Student PutStudent(Student student)
        {
            

            _context.Students.Update(student);

            Save();
            return student;


        }

        public bool DeleteStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(u => u.StudentId == id);


            _context.Students.Remove(student);
            Save();
            return true;

        }
        public bool checkId(int id)
        {
            return _context.Students.Any(u => u.StudentId == id);
        }

        //public bool NotNull(Student result)
        //{
        //   if(result!=null)
        //    {
        //        return true;
        //    }
        //   return false;
        //}


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
