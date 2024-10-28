namespace School.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual List<Student>? students { get; set; } = new List<Student>();
    }
}
