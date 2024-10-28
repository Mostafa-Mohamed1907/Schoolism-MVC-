using School.Models;
using School;
using School.Services;

namespace School.Services
{
    public class DepartmentRepository : IDepartmentRepository
    {
        SchoolDBContext context; //= new SchoolDB2Context();
        public DepartmentRepository(SchoolDBContext _context)
        {
            context = _context;
        }
        //CRUD

        public List<Department> GetAll()
        {
            List<Department> dept = context.departments.ToList();
            return dept;
        }
        public Department GetById(int id)
        {
            return context.departments.SingleOrDefault(s => s.Id == id);
        }
        public Department GetByName(string name)
        {
            return context.departments.SingleOrDefault(s => s.Name == name);
        }
        public int Insert(Department dept)
        {
            context.departments.Add(dept);
            return context.SaveChanges();
        }
        public int Update(int id, Department dept)
        {
            Department olddept = context.departments.SingleOrDefault(s => s.Id == id);
            olddept.Name = dept.Name;
            return context.SaveChanges();
        }
        public int Delete(int id)
        {
            Department oldDept = context.departments.SingleOrDefault(s => s.Id == id);
            context.departments.Remove(oldDept);
            return context.SaveChanges();
        }
    }
}




