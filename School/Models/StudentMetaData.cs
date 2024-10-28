using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class StudentMetaData
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [MaxLength(10, ErrorMessage = "This Field is Required with less than 10 char")]
        [MinLength(5, ErrorMessage = "This Field is Required with less than 5 char")]
        //[Unique] //Server Side
        [Remote(action: "TestUpdate", controller: "Student", ErrorMessage = "Name Has Been Found", AdditionalFields = nameof(Id))] //Client Side
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "This Field is Required")]
        public string Address { get; set; } = string.Empty;
        [Required(ErrorMessage = "This Field is Required")]
        public string Image { get; set; } = string.Empty;

        public virtual Department? Department { get; set; }
    }
}






