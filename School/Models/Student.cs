using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using School.Validators;
namespace School.Models
{
    [ModelMetadataType(typeof(StudentMetaData))]
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public virtual Department? Department { get; set; }
    }
}



namespace WebApplication2_SchoolWeb.Models
{
    
    public class Student
    {
        
    }
}

