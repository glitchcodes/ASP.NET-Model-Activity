using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TamposModelActivity.Models;

namespace TamposModelActivity.Controllers
{
    public class InstructorController : Controller
    {
        private List<Instructor> InstructorList = new List<Instructor>
        {
            new Instructor()
            {
                Id = 1, FirstName = "Nancy", LastName = "Carrillo", Rank = Rank.Instructor, HiringDate = DateTime.Parse("2022-09-11"),
                IsTenured = true
            },
            new Instructor()
            {
                Id = 2, FirstName = "Coleman", LastName = "Copeland", Rank = Rank.AssistantProfessor, HiringDate = DateTime.Parse("2022-09-11"),
                IsTenured = false
            },
            new Instructor()
            {
                Id = 3, FirstName = "Josiah", LastName = "Trujillo", Rank = Rank.AssociateProfessor, HiringDate = DateTime.Parse("2021-03-08"),
                IsTenured = true,
            },
            new Instructor()
            {
                Id = 4, FirstName = "Arron", LastName = "Braun", Rank = Rank.Professor, HiringDate = DateTime.Parse("2020-01-21"),
                IsTenured = true,
            },
        };
        
        public IActionResult Index()
        {
            return View(InstructorList);
        }

        [HttpGet]
        public IActionResult AddInstructor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddInstructor(Instructor newInstructor)
        {
            InstructorList.Add(newInstructor);
            return View("Index", InstructorList);
        }

        [HttpGet]
        public IActionResult EditInstructor(int Id)
        {
            var instructor = InstructorList.FirstOrDefault(ins => ins.Id == Id);

            if (instructor != null)
            {
                return View(instructor);
            }

            return NotFound();
        }

        public IActionResult EditInstructor(Instructor instructor)
        {
            var ins = InstructorList.FirstOrDefault(ins => ins.Id == instructor.Id);

            if (ins != null)
            {
                ins.Id = instructor.Id;
                ins.FirstName = instructor.FirstName;
                ins.LastName = instructor.LastName;
                ins.IsTenured = instructor.IsTenured;
                ins.Rank = instructor.Rank;
                ins.HiringDate = instructor.HiringDate;

                return View("Index", InstructorList);
            }

            return NotFound();
        }

        public IActionResult ShowDetails(int id)
        {
            Instructor? instructor = InstructorList.FirstOrDefault(ins => ins.Id == id);

            if (instructor != null)
            {
                return View(instructor);
            }

            return NotFound();
        }
    }
}