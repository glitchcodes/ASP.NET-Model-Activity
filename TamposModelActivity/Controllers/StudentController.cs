using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TamposModelActivity.Models;

namespace TamposModelActivity.Controllers
{
    public class StudentController : Controller
    {
        private List<Student> StudentList = new List<Student>
        {
            new Student()
            {
                Id = 1, FirstName = "Vincent", LastName = "Tampos", Course = Course.BSIT, AdmissionDate = DateTime.Parse("2022-09-11"),
                GPA = 1.2, Email = "vincentpaul.tampos.cics@ust.edu.ph"
            },
            new Student()
            {
                Id = 2, FirstName = "Ellen", LastName = "Richmond", Course = Course.BSCS, AdmissionDate = DateTime.Parse("2022-01-23"),
                GPA = 1.3, Email = "ellen.richmond.cics@ust.edu.ph"
            },
            new Student()
            {
                Id = 3, FirstName = "Paris", LastName = "Morris", Course = Course.BSIT, AdmissionDate = DateTime.Parse("2021-03-08"),
                GPA = 1.5, Email = "paris.morris.cics@ust.edu.ph"
            },
        };
        
        public IActionResult Index()
        {
            return View(StudentList);
        }

        public IActionResult ShowDetails(int id)
        {
            Student? student = StudentList.FirstOrDefault(st => st.Id == id);

            if (student != null)
            {
                return View(student);
            }

            return NotFound();
        }
    }
}