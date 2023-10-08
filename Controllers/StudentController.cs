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
        private readonly IStudentModel _studentModel;


        public StudentController(IStudentModel studentModel)
        {
            _studentModel = studentModel;
        }

        public IActionResult Index()
        {
            // var Student = GetStudentFromModel();
            var students = _studentModel.GetStudents();
            return View(students);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Save(Student student)
        {
            if (student.Id == 0)
            {
                _studentModel.AddNewStudent(student);
            }
            else
            {
                _studentModel.UpdateStudent(student);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var student = _studentModel.GetStudentById(id);
            if (student == null) return NotFound();
            return View(student);
        }
        public IActionResult Delete(int id)
        {
            var student = _studentModel.GetStudentById(id);
            if (student == null) return NotFound();
            _studentModel.DeleteStudent(student);
            return RedirectToAction("Index");
        }
    }
}
