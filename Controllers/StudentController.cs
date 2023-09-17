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
        public IActionResult Index()
        {
            // var students = GetStudentfromModel()
            // send students to Student's View

            var students = new List<Student>()
            {
                new() {Id = 1, Name = "Nguyen Van A",Age = 20, Address = "Da Nang"},
                new() {Id = 2, Name = "Nguyen Van B",Age = 23, Address = "Quang Nam"},
                new() {Id = 3, Name = "Nguyen Van C",Age = 22, Address = "Hue"},
            };

            ViewBag.StudentList = students;

            return View();
        }
    }
}
