using Microsoft.AspNetCore.Mvc;
using StudentMVC_ITI.Data;
using StudentMVC_ITI.Models;
using StudentMVC_ITI.Models.ViewModels;
using System.Linq;

namespace StudentMVC_ITI.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ITIContext _context;

        public DepartmentController(ITIContext context)
        {
            _context = context;
        }

        // GET: Department/GetAll
        public IActionResult GetAll_Department()
        {
            var departments = _context.Departments.ToList();
            return View(departments);
        }

        // GET: Department/Add
        [HttpGet]
        public IActionResult Add_Department()
        {
            return View();
        }

        // POST: Department/Add
        [HttpPost]
        public IActionResult Add_Department(AddDepartmentVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var department = new Department
            {
                DeptId = _context.Departments.ToList().Count + 1, // Simple ID generation logic
                DeptName = model.DeptName,
                DeptDesc = model.DeptDesc,
                DeptLocation = model.DeptLocation,
                DeptManager = model.DeptManager,
                ManagerHiredate = model.ManagerHiredate
            };

            _context.Departments.Add(department);
            _context.SaveChanges();

            return RedirectToAction(nameof(GetAll_Department));
        }


}
