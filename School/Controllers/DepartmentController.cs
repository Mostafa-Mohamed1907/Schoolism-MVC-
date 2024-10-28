using Microsoft.AspNetCore.Mvc;
using School.Models;
using School;
using School.Services;

namespace School.Controllers
{
    public class DepartmentController : Controller
    {
        IStudentRepository studentRepository;
        IDepartmentRepository departmentRepository;
        public DepartmentController(IStudentRepository studentRepository, IDepartmentRepository departmentRepository)
        {
            this.studentRepository = studentRepository;
            this.departmentRepository = departmentRepository;
        }
        //DepartmentController/Details
        public IActionResult Details()
        {
            var dept = departmentRepository.GetAll();
            return View(dept);
        }

        public IActionResult New()
        {
            return View();
        }
        public IActionResult SaveNew(Department department)
        {
            if (department.Name != null)
            {
                departmentRepository.Insert(department);
                return RedirectToAction("Details");
            }

            return View("New");
        }
        public IActionResult Update(int id)
        {
            var dept = departmentRepository.GetById(id);
            return View(dept);
        }
        public IActionResult SaveUpdate(int id, Department department)
        {
            if (department.Name != null)
            {
                var old_dept = departmentRepository.GetById(id);
                departmentRepository.Update(id, department);
                return RedirectToAction("Details");
            }
            return View("Update");
        }
        public IActionResult Delete(int id)
        {
            var dept = departmentRepository.GetById(id);
            if (dept != null)
            {
                departmentRepository.Delete(id);
                return RedirectToAction("Details");
            }
            return View("Details");
        }

    }
}


