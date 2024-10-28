using System.ComponentModel.DataAnnotations;
using School.Models; 
namespace School.Validators
{
    public class UniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var entity = (Student)validationContext.ObjectInstance;
            if (entity.Id != 0)
            {
                return ValidationResult.Success;
            }
            string name = value.ToString();
            SchoolDBContext context = new SchoolDBContext();
            var student = context.students!.SingleOrDefault(s => s.Name == name);

            if (student == null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Name Has Been Taken");
            }
        }

    }
}



