using Microsoft.EntityFrameworkCore;
using StudentEF.Models;
using System.Collections.Generic;

namespace StudentEF
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
