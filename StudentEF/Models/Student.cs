using System.ComponentModel.DataAnnotations;

namespace StudentEF.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Class { get; set; }

        public String Sub1 { get; set; }
        public String Sub2 { get; set; }
        public String Sub3 { get; set; }

        public List<Subject> Subjects { get; set; }


    }
}
