using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TamposModelActivity.Data;
using TamposModelActivity.Models;
using TamposModelActivity.Services;

namespace TamposModelActivity.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _dbContext;

        public StudentController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IActionResult Index()
        {
            return View(_dbContext.Students);
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddStudent(Student newStudent)
        {
            _dbContext.Students.Add(newStudent);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult EditStudent(int Id)
        {
            var student = _dbContext.Students.FirstOrDefault(st => st.Id == Id);

            if (student != null)
            {
                return View(student);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditStudent(Student student)
        {
            var st = _dbContext.Students.FirstOrDefault(st => st.Id == student.Id);

            if (st != null)
            {
                st.FirstName = student.FirstName;
                st.LastName = student.LastName;
                st.Email = student.Email;
                st.Course = student.Course;
                st.GPA = student.GPA;
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return NotFound();
        }
        
        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            Student? student = _dbContext.Students.FirstOrDefault(st => st.Id == id);

            if (student != null)
            {
                return View(student);
            }

            return NotFound();
        }
        
        [HttpPost]
        public IActionResult DeleteStudent(Student student)
        {
            var st = _dbContext.Students.FirstOrDefault(st => st.Id == student.Id);

            if (st != null)
            {
                _dbContext.Students.Remove(st);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return NotFound();
        }

        public IActionResult ShowDetails(int Id)
        {
            Student? student = _dbContext.Students.FirstOrDefault(st => st.Id == Id);

            if (student != null)
            {
                return View(student);
            }

            return NotFound();
        }
    }
}