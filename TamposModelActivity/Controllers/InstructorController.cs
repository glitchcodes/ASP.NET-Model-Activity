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