using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TamposModelActivity.Models;
using TamposModelActivity.Services;

namespace TamposModelActivity.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IMyFakeDataService _fakeData;

        public InstructorController(IMyFakeDataService fakeData)
        {
            _fakeData = fakeData;
        }
        
        public IActionResult Index()
        {
            return View(_fakeData.InstructorList);
        }

        [HttpGet]
        public IActionResult AddInstructor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddInstructor(Instructor newInstructor)
        {
            _fakeData.InstructorList.Add(newInstructor);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditInstructor(int Id)
        {
            var instructor = _fakeData.InstructorList.FirstOrDefault(ins => ins.Id == Id);

            if (instructor != null)
            {
                return View(instructor);
            }

            return NotFound();
        }

        public IActionResult EditInstructor(Instructor instructor)
        {
            var ins = _fakeData.InstructorList.FirstOrDefault(ins => ins.Id == instructor.Id);

            if (ins != null)
            {
                ins.Id = instructor.Id;
                ins.FirstName = instructor.FirstName;
                ins.LastName = instructor.LastName;
                ins.IsTenured = instructor.IsTenured;
                ins.Rank = instructor.Rank;
                ins.HiringDate = instructor.HiringDate;

                return RedirectToAction("Index");
            }

            return NotFound();
        }
        
        [HttpGet]
        public IActionResult DeleteInstructor(int Id)
        {
            var instructor = _fakeData.InstructorList.FirstOrDefault(ins => ins.Id == Id);

            if (instructor != null)
            {
                return View(instructor);
            }

            return NotFound();
        }
        
        [HttpPost]
        public IActionResult DeleteInstructor(Instructor instructor)
        {
            var ins = _fakeData.InstructorList.FirstOrDefault(ins => ins.Id == instructor.Id);

            if (ins != null)
            {
                _fakeData.InstructorList.Remove(ins);
                return RedirectToAction("Index");
            }

            return NotFound();
        }

        public IActionResult ShowDetails(int id)
        {
            Instructor? instructor = _fakeData.InstructorList.FirstOrDefault(ins => ins.Id == id);

            if (instructor != null)
            {
                return View(instructor);
            }

            return NotFound();
        }
    }
}