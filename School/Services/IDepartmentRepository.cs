using School.Models;

namespace School.Services
{
    public interface IDepartmentRepository
    {

        public List<Department> GetAll();
        public Department GetById(int id);
        public Department GetByName(string name);
        public int Insert(Department dept);
        public int Update(int id, Department dept);
        public int Delete(int id);
    }
}
