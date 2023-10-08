using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentMVC.Models;

namespace StudentMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly DataContext _context;
        public StudentController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // var Student = GetStudentFromModel();
            var students = _context.Students.ToList();
            return View(students);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Save(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
