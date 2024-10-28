using Microsoft.EntityFrameworkCore;
using School.Models;
namespace School
{
    public class SchoolDBContext:DbContext
    {
        public SchoolDBContext() { }
        public SchoolDBContext(DbContextOptions options):base(options) { }

        public virtual DbSet<Student>? students { get;set; }
        public virtual DbSet<Department>? departments { get; set; }
    }
}
