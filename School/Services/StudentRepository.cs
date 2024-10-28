using Microsoft.EntityFrameworkCore;
using School.Models;
using School.Services;

namespace School.Services
{
    public class StudentRepository : IStudentRepository
    {
        SchoolDBContext context; //= new SchoolDB2Context();
        public StudentRepository(SchoolDBContext _context)
        {
            context = _context;
        }
        //CRUD

        public List<Student> GetAll()
        {
            List<Student> students = context.students.ToList();
            return students;
        }
        public Student GetById(int id)
        {
            return context.students.Include(x => x.Department).SingleOrDefault(s => s.Id == id);
        }
        public Student GetByName(string name)
        {
            // List<Student> std = context.students.Include(x => x.Department).Where(s => s.Name.Contains(name)).ToList(); // Use Contains for partial match
            return context.students.SingleOrDefault(s => s.Name == name);
        }
        public int Insert(Student std)
        {
            context.students.Add(std);
            return context.SaveChanges();
        }
        public int Update(int id, Student std)
        {
            Student oldStd = context.students.Include(s => s.Department).SingleOrDefault(s => s.Id == id);
            oldStd.Name = std.Name;
            oldStd.Address = std.Address;
            oldStd.Image = std.Image;
            oldStd.Department = std.Department;

            return context.SaveChanges();
        }
        public int Delete(int id)
        {
            Student oldStd = context.students.SingleOrDefault(s => s.Id == id);
            context.students.Remove(oldStd);
            return context.SaveChanges();
        }
    }
}
