
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using Microsoft.AspNetCore.Authorization;
using School.Services;
using School.ViewModel;
using School.Models;

namespace School.Controllers
{
    
    public class StudentController : Controller
    {
        IStudentRepository studentRepository;
        IDepartmentRepository departmentRepository;

        public StudentController(IStudentRepository studentRepository, IDepartmentRepository departmentRepository)
        {
            this.studentRepository = studentRepository;
            this.departmentRepository = departmentRepository;
        }

        //StudentController/Index/2
        public IActionResult Index(int id)
        {
            var student = studentRepository.GetById(id);
            return View(student);
        }

        public IActionResult Inndex()
        {
            var stds = studentRepository.GetAll();

            List<string> data = new List<string>();
            data.Add("First Year");
            data.Add("Second Year");
            data.Add("Third Year");
            data.Add("Fourth Year");
            ViewData["Data"] = data;

            ViewBag.msg = "Hello World";
            return View(stds);
        }

        public IActionResult Ind2ex(int id)
        {
            var student = studentRepository.GetById(id);

            StudentDepartmentNameViewModel StudentViewModel = new StudentDepartmentNameViewModel();

            if (student != null)
            {
                StudentViewModel.Id = student.Id;
                StudentViewModel.StudentName = student.Name;
                StudentViewModel.DepartmentName = student.Department!.Name;
            }
            if (StudentViewModel.DepartmentName == "IT") { StudentViewModel.Color = "Red"; }
            else { StudentViewModel.Color = "Black"; }

            return View(StudentViewModel);
        }
        public IActionResult Details()
        {
            var students = studentRepository.GetAll();
            return View(students);
        }
        public IActionResult New(Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepository.Insert(student);
                return RedirectToAction("Details");
            }

            return View("New", student);
        }
        public IActionResult Update(int id)
        {
            var students = studentRepository.GetById(id);
            var dept = departmentRepository.GetAll();
            ViewData["data"] = dept;
            return View("Update", students);
        }

        public IActionResult SaveUpdate(Student std)
        {

            //var student = studentRepository.GetById(std.Id);
            //if (std.Name != null)
            if (ModelState.IsValid)
            {

                //var department = departmentRepository.GetById(std.Department.Id);
                studentRepository.Update(std.Id, std);
                //if (department != null)
                //{
                //    std.Department = department; // Assigning the selected department
                //}
                return RedirectToAction("Details");
            }

            var depart = departmentRepository.GetAll();
            ViewData["data"] = depart;
            //student.Department = depart; // Assigning the selected department
            return View("Update", std);
        }
        public IActionResult TestUpdate(string name, int id)
        {
            //var student = studentRepository.GetByName(name);
            var sstudent = studentRepository.GetByName(name);
            if (sstudent.Name == null || sstudent.Id == id)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        public IActionResult Search(string searchTerm)
        {
            //var studdents = context.students.Where(s => s.Name.Contains(searchTerm)).ToList();

            //var studdents = string.IsNullOrEmpty(searchTerm)
            //    ? studentRepository.GetAll()
            //    : studentRepository.GetByName(searchTerm);

            //return PartialView("_StudentTable", studdents);
            return PartialView("_StudentTable");
        }
    }
}


//OLD_Code_Before_Seperation_Into_Services
/*
 
    SchoolDB2Context context = new SchoolDB2Context();
        //StudentController/Index/2
        public IActionResult Index(int id)
        {
            var student = context.students!.Where(x => x.Id == id).FirstOrDefault();
            return View(student);
        }

        public IActionResult Inndex()
        {
            var stds = context.students!.ToList();

            List <string> data = new List <string>();
            data.Add("First Year");
            data.Add("Second Year");
            data.Add("Third Year");
            data.Add("Fourth Year");
            ViewData["Data"] = data;

            ViewBag.msg = "Hello World";
            return View(stds);
        }

        public IActionResult Ind2ex(int id)
        {
            var student = context.students!.Include(x => x.Department).SingleOrDefault(s=>s.Id==id);

            StudentDepartmentNameViewModel StudentViewModel = new StudentDepartmentNameViewModel();

            if(student!=null)
            {
                StudentViewModel.Id = student.Id;
                StudentViewModel.StudentName = student.Name;
                StudentViewModel.DepartmentName = student.Department!.Name;
            }
            if (StudentViewModel.DepartmentName == "IT") { StudentViewModel.Color = "Red"; }
            else { StudentViewModel.Color = "Black"; }
          
            return View(StudentViewModel);
        }
        public IActionResult Details()
        {
            var students = context.students!.Include("Department").ToList();
            return View(students);
        }
        public IActionResult Update(int id)
        {
            var students = context.students!.Include("Department").SingleOrDefault(d=>d.Id==id);
            var dept = context.departments!.ToList();
            ViewData["data"] = dept;
            return View("Update", students);
        }

        public IActionResult SaveUpdate(Student std)
        {

            var student = context.students!.Include("Department").SingleOrDefault(d => d.Id == std.Id);
            //if (std.Name != null)
            if (ModelState.IsValid)
            {
                
                student!.Name = std.Name;
                student.Address = std.Address;
                student.Image = std.Image;

                var department = context.departments!.Find(std.Department!.Id);
                if (department != null)
                {
                    student.Department = department; // Assigning the selected department
                }
                context.SaveChanges();
                return RedirectToAction("Details");
            }

            var depart = context.departments!.ToList();
            ViewData["data"]=depart;
            //student.Department = depart; // Assigning the selected department
            return View("Update", std);
        }
        public IActionResult TestUpdate(string name, int id)
        {
            var student = context.students!.SingleOrDefault(s => s.Name == name);
            if(student==null || student.Id==id)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        public IActionResult Search(string searchTerm)
        {
            //var studdents = context.students.Where(s => s.Name.Contains(searchTerm)).ToList();
            var studdents = string.IsNullOrEmpty(searchTerm)
                ? context.students!.ToList()
                : context.students!.Where(s => s.Name.Contains(searchTerm)).ToList();

            return PartialView("_StudentTable", studdents);
        }
 */
