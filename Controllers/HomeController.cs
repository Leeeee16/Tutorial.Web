using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutorial.Web.Models;
using Tutorial.Web.Services;
using Tutorial.Web.ViewModels;

namespace Tutorial.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Student> _repository;

        public HomeController(IRepository<Student> repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var list = _repository.GetAll();
            var vms = list.Select(s => new StudentViewModel()
            {
                Id = s.Id,
                Name = $"{s.FirstName} {s.LastName}",
                Age = DateTime.Today.Year - s.Birthday.Year
            });

            var vm = new HomeIndexViewModel
            {
                Students = vms
            };

            return View(vm);
        }

        public IActionResult Detail(int id)
        {
            var student = _repository.GetById(id);
            if (student == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        [Authorize] //只有登陆用户才能创建
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize] //只有登陆用户才能创建
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentCreateViewModel student)
        {
            if (ModelState.IsValid)
            {
                var newStudent = new Student
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Birthday = student.BirthDate,
                    Gender = student.Gender
                };
                var newModel = _repository.Add(newStudent);

                return RedirectToAction(nameof(Detail), new { id = newModel.Id });
            }

            ModelState.AddModelError(string.Empty, "Model Level Error!");

            return View();
        }
    }
}