using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TamposModelActivity.Models;
using TamposModelActivity.Services;

namespace TamposModelActivity.Controllers
{
    public class StudentController : Controller
    {
        private readonly IMyFakeDataService _fakeData;

        public StudentController(IMyFakeDataService fakeData)
        {
            _fakeData = fakeData;
        }
        
        public IActionResult Index()
        {
            return View(_fakeData.StudentList);
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddStudent(Student newStudent)
        {
            _fakeData.StudentList.Add(newStudent);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult EditStudent(int Id)
        {
            var student = _fakeData.StudentList.FirstOrDefault(st => st.Id == Id);

            if (student != null)
            {
                return View(student);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditStudent(Student student)
        {
            var st = _fakeData.StudentList.FirstOrDefault(st => st.Id == student.Id);

            if (st != null)
            {
                st.Id = student.Id;
                st.FirstName = student.FirstName;
                st.LastName = student.LastName;
                st.Email = student.Email;
                st.Course = student.Course;
                st.GPA = student.GPA;

                return RedirectToAction("Index");
            }

            return NotFound();
        }
        
        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            Student? student = _fakeData.StudentList.FirstOrDefault(st => st.Id == id);

            if (student != null)
            {
                return View(student);
            }

            return NotFound();
        }
        
        [HttpPost]
        public IActionResult DeleteStudent(Student student)
        {
            var st = _fakeData.StudentList.FirstOrDefault(st => st.Id == student.Id);

            if (st != null)
            {
                _fakeData.StudentList.Remove(st);
                return RedirectToAction("Index");
            }
            
            return NotFound();
        }

        public IActionResult ShowDetails(int Id)
        {
            Student? student = _fakeData.StudentList.FirstOrDefault(st => st.Id == Id);

            if (student != null)
            {
                return View(student);
            }

            return NotFound();
        }
    }
}