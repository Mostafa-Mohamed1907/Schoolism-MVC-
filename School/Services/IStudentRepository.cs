using School.Models;

namespace School.Services
{
    public interface IStudentRepository
    {
        public List<Student> GetAll();
        public Student GetById(int id);
        public Student GetByName(string name);
        public int Insert(Student std);
        public int Update(int id, Student std);
        public int Delete(int id);
    }

}
