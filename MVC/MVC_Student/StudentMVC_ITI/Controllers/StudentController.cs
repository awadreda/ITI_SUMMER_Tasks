using Microsoft.AspNetCore.Mvc;
using StudentMVC_ITI.Data;
using StudentMVC_ITI.Models;
using StudentMVC_ITI.Models.ViewModels;
using System.Linq;

namespace StudentMVC_ITI.Controllers
{
    public class StudentController : Controller
    {
        private readonly ITIContext _context;

        public StudentController(ITIContext context)
        {
            _context = context;
        }

        // 1. GetStsAllData
        public IActionResult GetStsAllData()
        {
            var students = _context.Students
                .Select(s => new StudentListVM
                {
                    StName = s.StFname + " " + s.StLname,
                    Id = s.StId,
                    StAge = s.StAge,
                    DeptName = s.Dept.DeptName,
                    ManagerName = s.Dept.DeptManagerNavigation.InsName
                })
                .ToList();

            return View(students);
        }

        // 2. Details
        public IActionResult Details(int id)
        {
            var student = _context.Students
                .Where(s => s.StId == id)
                .Select(s => new StudentDetailsVM
                {
                    StdName = s.StFname + " " + s.StLname,
                    StdAddress = s.StAddress,
                    DeptName = s.Dept.DeptName,
                    ManagerName = s.Dept.DeptManagerNavigation.InsName,
                    StageColor = s.StAge < 25 ? "green" : "red"
                })
                .FirstOrDefault();

            if (student == null)
                return NotFound();

            return View(student);
        }
        
         [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        // POST: AddStudent
        [HttpPost]
        public IActionResult AddStudent(AddStudentVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var student = new Student
            {
                StFname = model.StFname,
                StLname = model.StLname,
                StAge = model.StAge,
                StAddress = model.StAddress,
                DeptId = model.DeptId
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            return RedirectToAction(nameof(GetStsAllData));
        }






    }
}
