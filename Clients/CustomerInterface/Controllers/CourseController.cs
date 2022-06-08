using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CustomerInterface.Models;
using CustomerInterface.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomerInterface.Controllers
{
    [Route("[controller]")]
    public class CourseController : Controller
    {
        private readonly IConfiguration _config;
        private readonly CourseServiceModel _courseService;
        public CourseController(IConfiguration config)
        {
            _config = config;
            _courseService = new CourseServiceModel(_config);
        }

        [HttpGet]
        public async Task<IActionResult> Index() 
        {
           try{

               var courses = await _courseService.ListAllCourses();
               return View("Index", courses);

           }
           catch(System.Exception)
           {
               throw;
           }
            
        }
        

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {

            try
            {
                var course = await _courseService.FindByIdCourse(id);
                return View("Details", course);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View("Error");
            }
            
        }
        [HttpGet("Search/{category}")]
        public async Task<IActionResult> Search(string category)
        {

            try
            {
                var course = await _courseService.FindByCategory(category);
                return View("Search",course);
                // return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View("Error");
            }
            
        }
        [HttpGet("Create")]
        public IActionResult Create()
        {
            var course =  new CreateCourseViewModel();
            return View("Create", course);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateCourseViewModel course){

            if(!ModelState.IsValid)
            {
                return View("Create", course);
            }

            if(await _courseService.CreateCourse(course))
            {
                return View("Confirmation");
            }
            return View("Create", course);
        }
    }
}